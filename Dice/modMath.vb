Imports System.Runtime.CompilerServices

Module modMath

    <Extension()>
    Public Function Precedence(ByVal c As String) As Integer
        Select Case c
            Case "("
                Return 5
            Case "d"
                Return 4
            Case "^"
                Return 3
            Case "*", "/"
                Return 2
            Case "+", "-"
                Return 1
            Case ")"
                Return 0
            Case Else
                Return -1
        End Select
    End Function

    <Extension()>
    Public Function Postfix(ByVal strInfix As String) As String
        Dim res As String = ""
        Dim stack As New Stack(Of String)
        For Each c As String In strInfix
            If Precedence(c) >= 0 Then
                If stack.Count = 0 Then
                    stack.Push(c)
                Else
                    Dim op As String = stack.Pop
                    While Precedence(c) <= Precedence(op)
                        res &= op
                        If stack.Count > 0 Then
                            op = stack.Pop
                        Else
                            op = ""
                        End If
                    End While
                    If op <> "" Then
                        stack.Push(op)
                    End If
                    stack.Push(c)
                End If
            Else
                res &= c
            End If
        Next
        While stack.Count > 0
            res &= stack.Pop
        End While
        Return res.Replace("(", "").Replace(")", "")
    End Function

    <Extension()>
    Public Function EvaluatePostfix(ByVal strPostfix As String) As Long
        Dim stack As New Stack(Of Long)

        For Each c As String In strPostfix
            If Precedence(c) < 0 Then
                stack.Push(Long.Parse(c))
            Else
                Dim op2 As Long = stack.Pop
                Dim op1 As Long = stack.Pop
                Dim res As Long = 0
                Select Case c
                    Case "d"
                        res = roll(op1, op2)
                    Case "*"
                        res = op1 * op2
                    Case "/"
                        res = op1 \ op2
                    Case "+"
                        res = op1 + op2
                    Case "-"
                        res = op1 - op2
                    Case "^"
                        res = CLng(Math.Pow(op1, op2))
                End Select
                stack.Push(res)
            End If
        Next

        Return stack.Pop
    End Function

    Private Function roll(op1 As Long, op2 As Long) As Long
        Dim random As New Random
        Dim res As Long = 0
        For i As Long = 1 To op1
            res += random.Next(1, CInt(op2 + 1))
        Next
        Return res
    End Function

End Module
