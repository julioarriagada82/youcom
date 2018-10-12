Option Strict Off
Option Explicit On

Public Class EncPwd
    'Para el manejo de los errores
    '====================================================================================
    Const MODULO As String = "KtEncPwd"
    Const TIPO As String = "EncPwd"

    Const LARGO_PWD As Short = 50
    '====================================================================================

    Public Shared Sub Ejecutar(ByVal pvarPassword As String, _
                               ByVal pvarOperadorNro As Integer, _
                               ByRef pvarEncriptado As String)

        Try
            Encriptar(pvarPassword, _
                      pvarOperadorNro, _
                      LARGO_PWD, _
                      pvarEncriptado)

        Catch eobjException As Exception
            Throw eobjException

        End Try

    End Sub

    Private Shared Sub Encriptar(ByVal pvarPlano As String, _
                                 ByVal pvarSemilla As Integer, _
                                 ByVal pvarLen As Short, _
                                 ByRef pvarEncriptado As String)

        Dim wvarAscSem As Byte
        Dim wvarI As Short

        Dim wvarBitPaso As Byte
        Dim wvarBitAColocar As Byte
        Dim wvarPrimerByte As Byte

        Dim wvarCaracter As Byte
        Dim wvarCadenaCompleta As String
        Dim wvarSemilla As String

        Dim wvarRelleno As String = ""

        Try

            If pvarPlano = "" Then
                Exit Sub
            End If

            wvarSemilla = Str(pvarSemilla)
            wvarAscSem = 255
            For wvarI = 1 To Len(wvarSemilla)
                wvarAscSem = wvarAscSem Xor Asc(Mid(wvarSemilla, wvarI, 1))
                If wvarAscSem = 0 Then
                    wvarAscSem = 255
                End If
            Next wvarI

            'Trabajo el primer caracter
            wvarBitPaso = Asc(Mid(pvarPlano, 1, 1)) And 1

            wvarPrimerByte = Int(Asc(Mid(pvarPlano, 1, 1)) / 2)

            wvarCadenaCompleta = ""

            For wvarI = 2 To Len(pvarPlano)
                wvarBitAColocar = wvarBitPaso * 128
                wvarBitPaso = Asc(Mid(pvarPlano, wvarI, 1)) And 1

                wvarCaracter = (Int(Asc(Mid(pvarPlano, wvarI, 1)) / 2) Or wvarBitAColocar) Xor wvarAscSem
                If wvarCaracter < 14 Or wvarCaracter = 34 Or wvarCaracter = 39 Then
                    wvarCaracter = wvarCaracter + 20
                End If

                wvarCadenaCompleta = wvarCadenaCompleta & Chr(wvarCaracter)

                If (wvarAscSem Or 1) = 1 Then
                    wvarAscSem = Int(wvarAscSem / 2) + 128
                Else
                    wvarAscSem = Int(wvarAscSem / 2)
                End If

            Next wvarI

            wvarBitAColocar = wvarBitPaso * 128
            wvarPrimerByte = (wvarPrimerByte Or wvarBitAColocar) Xor wvarAscSem

            If wvarPrimerByte = 0 Then
                wvarPrimerByte = Asc("L")
            End If

            wvarCadenaCompleta = Chr(wvarPrimerByte) & wvarCadenaCompleta

            Do While Len(wvarCadenaCompleta) < pvarLen

                pvarSemilla = 1000 + pvarSemilla Mod 2000000000
                Encriptar(wvarCadenaCompleta, _
                          pvarSemilla, _
                          Len(wvarCadenaCompleta), _
                          wvarRelleno)

                wvarCadenaCompleta = wvarCadenaCompleta & wvarRelleno

            Loop

            wvarCadenaCompleta = Left(wvarCadenaCompleta, pvarLen)

            pvarEncriptado = wvarCadenaCompleta

        Catch eobjException As Exception
            Throw eobjException

        End Try

    End Sub
End Class