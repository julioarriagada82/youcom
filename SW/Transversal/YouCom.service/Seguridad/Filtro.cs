using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace YouCom.Service.Seguridad
{
   public class Filtro
    {
        /// <summary>
        ///  variable privada con el texto filtrado 
        /// </summary>
        private static string filtered_text = string.Empty;

        /// <summary>
        ///  arreglo unidimensional con los tags html permitidos 
        ///  "a", "em", "strong", "cite", "blockquote", "code", "ul", "ol", "li", "dl", "dt", "dd"
        /// </summary>

        private static string[] allowed_tags = new string[12] { "a", "em", "strong", "cite", "blockquote", "code", "ul", "ol", "li", "dl", "dt", "dd" };

        /// <summary>
        ///  arreglo unidimensional con los procolos permitidos 
        ///  "ftp", "http", "https", "irc", "mailto", "news", "nntp", "rtsp", "sftp", "ssh", "tel", "telnet", "webcal"
        /// </summary>

        private static string[] allowed_protocols = new string[13] { "ftp", "http", "https", "irc", "mailto", "news", "nntp", "rtsp", "sftp", "ssh", "tel", "telnet", "webcal" };

        /// <summary>
        ///  método privado para sanitizar el texto de entrada
        /// </summary>
        private static string _filtro_xss_split(Match m)
        {

            string element = Convert.ToString(m.Value);


            if (element.Substring(0, 1) != "<")
            {
                return "&gt;";
            }
            else if (element.Length == 1)
            {
                // We matched a lone "<" character
                return "&lt;";
            }

            MatchCollection matches = Regex.Matches(element, @"^<\s*(/\s*)?([a-zA-Z0-9]+)([^>]*)>?|(<!--.*?-->)$");

            if (matches.Count == 0)
            {
                // Seriously malformed
                return string.Empty;
            }

            string slash, elem, attrlist, comment;

            try
            {
                slash = Convert.ToString(matches[0].Value).Trim();
            }
            catch (NullReferenceException e)
            {
                slash = string.Empty;
            }

            try
            {
                elem = Convert.ToString(matches[1].Value);
            }
            catch (NullReferenceException e)
            {
                elem = string.Empty;
            }

            try
            {
                attrlist = Convert.ToString(matches[2].Value);
            }
            catch (NullReferenceException e)
            {
                attrlist = string.Empty;
            }

            try
            {
                comment = Convert.ToString(matches[3].Value);
            }
            catch (NullReferenceException e)
            {
                comment = string.Empty;
            }



            if (comment.Length != 0)
            {
                elem = "!--";
            }
            if (elem.Length != 0)
            {
                bool disalowed = false;
                for (int i = 0; i < Filtro.allowed_tags.Length; i++)
                {
                    if (Filtro.allowed_tags[i] == elem)
                    {
                        disalowed = true;
                        break;
                    }
                }

                if (disalowed == true)
                {
                    // Disallowed HTML element
                    return string.Empty;
                }
            }

            if (comment.Length != 0)
            {
                return comment;
            }

            if (slash != string.Empty)
            {
                return "</" + elem + ">";
            }

            // Is there a closing XHTML slash at the end of the attributes?
            Match match = Regex.Match(attrlist, @"(\s?)/\s*$");
            string xhtml_slash = match.Success == true ? " /" : string.Empty;
            attrlist = Regex.Replace(attrlist, @"(\s?)/\s*$", "$1");

            // Clean up attributes
            string[] tem_arr = Filtro._filter_xss_attributes(attrlist);
            string attr2 = string.Join(" ", tem_arr);
            attr2 = Regex.Replace(attr2, @"[<>]", "");
            attr2 = (attr2.Length > 0) ? " " + attr2 : string.Empty;


            return "<" + elem + attr2 + xhtml_slash + ">";


        }

        /// <summary>
        ///  método privado para sanitizar los attributos del los tags html
        /// </summary>

        private static string[] _filter_xss_attributes(string attr)
        {
            List<string> attrarr = new List<string>();
            int mode = 0;
            int working;
            string attrname = string.Empty;
            MatchCollection matches;
            bool skip = false;

            while (attr.Length != 0)
            {

                // Was the last operation successful?
                working = 0;

                switch (mode)
                {
                    case 0:
                        matches = Regex.Matches(attr, @"^([-a-zA-Z]+)");
                        if (matches.Count > 0)
                        {
                            attrname = Convert.ToString(matches[0].Value);
                            skip = (attrname == "style" || attrname.Substring(0, 2) == "on") ? true : false;
                            working = mode = 1;
                            attr = Regex.Replace(attr, "^[-a-zA-Z]+", "");
                        }
                        break;
                    case 1:
                        // Equals sign or valueless ("selected")
                        matches = Regex.Matches(attr, @"^\s*=\s*");
                        if (matches.Count > 0)
                        {
                            working = 1;
                            mode = 2;
                            attr = Regex.Replace(attr, @"^\s*=\s*)", "");
                            break;
                        }

                        matches = Regex.Matches(attr, @"^\s+");
                        if (matches.Count > 0)
                        {
                            working = 1;
                            mode = 0;
                            if (skip == false)
                            {
                                attrarr.Add(attrname);
                            }
                            attr = Regex.Replace(attr, @"^\s+", "");
                        }
                        break;
                    case 2:
                        // Attribute value, a URL after href= for instance
                        matches = Regex.Matches(attr, @"^""([^""]*)""(\s+|$)");
                        if (matches.Count > 0)
                        {
                            string thisval;
                            try
                            {
                                thisval = Filtro.filter_xss_bad_protocol(Convert.ToString(matches[1].Value));
                            }
                            catch (NullReferenceException e)
                            {
                                thisval = string.Empty;
                            }

                            if (skip == false && thisval != string.Empty)
                            {
                                attrarr.Add(attrname + '=' + '"' + thisval + '"');
                            }
                            working = 1;
                            mode = 0;
                            attr = Regex.Replace(attr, @"^""([^""]*)""(\s+|$)", "");
                            break;
                        }

                        matches = Regex.Matches(attr, @"^'([^']*)'(\s+|$)");
                        if (matches.Count > 0)
                        {
                            string thisval;
                            try
                            {
                                thisval = Filtro.filter_xss_bad_protocol(Convert.ToString(matches[1].Value));
                            }
                            catch (NullReferenceException e)
                            {
                                thisval = string.Empty;
                            }

                            if (skip == false && thisval != string.Empty)
                            {
                                attrarr.Add(attrname + '=' + '"' + thisval + '"');
                            }
                            working = 1;
                            mode = 0;
                            attr = Regex.Replace(attr, @"^'([^']*)'(\s+|$)", "");
                            break;
                        }

                        matches = Regex.Matches(attr, @"^([^\s\""']+)(\s+|$)");
                        if (matches.Count > 0)
                        {
                            string thisval;
                            try
                            {
                                thisval = Filtro.filter_xss_bad_protocol(Convert.ToString(matches[1].Value));
                            }
                            catch (NullReferenceException e)
                            {
                                thisval = string.Empty;
                            }
                            if (skip == false && thisval != string.Empty)
                            {
                                attrarr.Add(attrname + "=\"" + thisval + "\"");
                            }
                            working = 1;
                            mode = 0;
                            attr = Regex.Replace(attr, @"^([^\s\""']+)(\s+|$)", "");
                        }
                        break;
                } // fin switch

                if (working == 0)
                {
                    // not well formed, remove and try again
                    attr = Regex.Replace(attr, @"^(""[^""]*(""|$)|'[^']*('|$)|\S)*\s*", "");
                    mode = 0;
                }
            } // end while

            if (mode == 1 && skip == false)
            {
                attrarr.Add(attrname);
            }

            return attrarr.ToArray();

        }



        /// <summary>
        ///  obtiene la representación en textro plano de un attributi
        /// </summary>
        private static string filter_xss_bad_protocol(string str)
        {
            str = HttpUtility.HtmlEncode(str);
            return HttpUtility.HtmlEncode(_strip_dangerous_protocols(str));
        }

        /// <summary>
        ///  Sanitiza protocolos potencialmente peligrosos
        /// </summary>  
        private static string _strip_dangerous_protocols(string uri)
        {
            string before = string.Empty;
            int colonpos = 0;
            string protocol = string.Empty;
            // Iteratively remove any invalid protocol found.
            do
            {
                before = uri;
                colonpos = uri.IndexOf(':');
                if (colonpos > 0)
                {
                    // We found a colon, possibly a protocol. Verify.
                    protocol = uri.Substring(0, colonpos);
                    // If a colon is preceded by a slash, question mark or hash, it cannot
                    // possibly be part of the URL scheme. This must be a relative URL, which
                    // inherits the (safe) protocol of the base document.
                    Match match = Regex.Match(protocol, @"[/?#]");
                    if (match.Success == true)
                    {
                        break;
                    }

                    // Check if this is a disallowed protocol. Per RFC2616, section 3.2.3
                    // (URI Comparison) scheme comparison must be case-insensitive.
                    bool allowed = false;
                    for (int i = 0; i < Filtro.allowed_protocols.Length; i++)
                    {
                        if (Filtro.allowed_protocols[i].ToLower() == protocol.ToLower())
                        {
                            allowed = true;
                            break;
                        }
                    }

                    if (allowed == false)
                    {
                        uri = uri.Substring(colonpos + 1);
                    }
                } // fin if.
            } while (before != uri);

            return uri;
        }

        /// <summary>
        ///  método publico para sanitizar el texto de entrada 
        /// </summary> 
        public static string check_plain(string str)
        {
            return HttpUtility.HtmlEncode(str);
        }




        /// <summary>
        ///  método publico para reedefinir los tags permitidos
        /// </summary>
        public static void _define_allowed_tags(string[] m)
        {
            Filtro.allowed_tags = m;
        }


        /// <summary>
        ///  método statico para llamar al filtro xss
        /// </summary>
        public static string filtro_xss(string text)
        {
            // assign  text to private variable
            Filtro.filtered_text = text;

            Filtro._define_allowed_tags(Filtro.allowed_tags);

            // Remove NULL characters (ignored by some browsers)
            Filtro.filtered_text.Replace(Convert.ToString(0), string.Empty);
            // Remove Netscape 4 JS entities
            Filtro.filtered_text = Regex.Replace(Filtro.filtered_text, @"&\s*\{[^}]*(\}\s*;?|$)", "");
            // Defuse all HTML entities
            Filtro.filtered_text.Replace("&", "&amp;");
            // Decimal numeric entities
            Filtro.filtered_text = Regex.Replace(Filtro.filtered_text, @"&amp;#([0-9]+;)", "&$1");
            // Hexadecimal numeric entities
            Filtro.filtered_text = Regex.Replace(Filtro.filtered_text, @"&amp;#[Xx]0*((?:[0-9A-Fa-f]{2})+;)", "&#x$1");
            // Named entities
            Filtro.filtered_text = Regex.Replace(Filtro.filtered_text, @"&amp;([A-Za-z][A-Za-z0-9]*;)", "&$1");

            Filtro.filtered_text = Regex.Replace(Filtro.filtered_text, @"(<(?=[^a-zA-Z!/])|<!--.*?-->|<[^>]*(>|$)|>)", new MatchEvaluator(Filtro._filtro_xss_split));

            return Filtro.filtered_text;

        }



        //
        // TODO: Add constructor logic here
        //
    }
}
