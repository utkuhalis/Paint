Public Class Form1
    Public grafik As Graphics
    Private resim_cizim As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height - 25)
    Private grafik_cizim As Graphics = Graphics.FromImage(resim_cizim)
    Private kalem As New System.Drawing.SolidBrush(System.Drawing.Color.Black)

    Dim k As Integer
    Dim tx, ty As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        k = 10
        grafik = PictureBox1.CreateGraphics()
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            grafik.FillEllipse(kalem, New Rectangle(e.X - 5, e.Y - 5, k, k))
            grafik_cizim.FillEllipse(kalem, New Rectangle(e.X - 5, e.Y - 5, k, k))
        End If

        tx = e.X
        ty = e.Y
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim open As New OpenFileDialog

        open.Title = "Resim Aç"
        open.Filter = "Png File(*.png)|*.png| Jpg File(*.jpg)|*.jpg"

        If open.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.SizeMode = ImageLayout.Stretch
            PictureBox1.Image = Image.FromFile(open.FileName)
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        k = 10
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        k = 20
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        k = 30
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            kalem.Color = ColorDialog1.Color
        End If
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        End
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub ToolStripSplitButton2_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSplitButton2.ButtonClick
        MsgBox("Sadece çizilen resim kayıt edilebilir.", MsgBoxStyle.Information, "Dikkat!")
        Dim save As New SaveFileDialog

        save.Title = "Resim Kaydet"
        save.Filter = "Png File(*.png)|*.png"

        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            resim_cizim.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Png)
        End If
    End Sub
End Class
