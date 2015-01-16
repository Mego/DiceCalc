Public Class Form1

    Private Sub btnEval_Click(sender As Object, e As EventArgs) Handles btnEval.Click
        lblResult.Text = "Result: " & txtInput.Text.Postfix.EvaluatePostfix
    End Sub
End Class
