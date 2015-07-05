Imports Emgu.CV
Imports Emgu.CV.Structure
Imports Emgu.Util
Public Class Form1
    Dim Capturez As Capture = New Capture
    Dim Videoz As VideoWriter
    Dim imagez As Image(Of Bgr, Byte)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button3.Visible = False

        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        imagez = Capturez.RetrieveBgrFrame
        Videoz.WriteFrame(imagez)
        PictureBox1.Image = imagez.ToBitmap()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

     
        'CV_FOURCC("P","I&quo­t;,"M","1") = MPEG-1
        'CV_FOURCC("M","J&quo­t;,"P","G") = motion-jpeg
        'CV_FOURCC("M", "P", "4", "2") = MPEG-4.2
        'CV_FOURCC("D", "I", "V", "3") = MPEG-4.3
        'CV_FOURCC("D", "I", "V", "X") = MPEG - 4
        'CV_FOURCC("U", "2", "6", "3") = H263
        'CV_FOURCC("I", "2", "6", "3") = H263I
        'CV_FOURCC("F", "L", "V", "1") = FLV1
        SaveFileDialog1.Title = "Save Video as"
        SaveFileDialog1.DefaultExt = "MP4"
        SaveFileDialog1.Filter = "MPEG-4 Video Files (*.mp4)|*.mp4"

        Dim Destination As String = "D:\defa.mpg"
        Dim compression As Integer = CvInvoke.CV_FOURCC("D", "I", "V", "x")

        Dim fps As Integer = 5
        Dim width As Integer = PictureBox1.Width
        Dim Height As Integer = PictureBox1.Height
        Dim color As Boolean = True

        Videoz = New VideoWriter(Destination, compression, fps, width, Height, color)
        Button1.Visible = False
        Button3.Visible = True

        Timer2.Stop()

        Timer1.Start()


        Catch ex As Exception
            MsgBox("Ops, Something Wrong : Error Code : " + ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        imagez = Capturez.RetrieveBgrFrame
        PictureBox1.Image = imagez.ToBitmap()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SaveFileDialog1.Title = "Save Image as"
        SaveFileDialog1.DefaultExt = "JPG"
        SaveFileDialog1.Filter = "JPEG Image Files (*.jpg)|*.jpg"
        Dim Destination As String
        If (SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
            Destination = SaveFileDialog1.FileName
        Else
            Exit Sub
        End If
        PictureBox1.Image.Save(Destination, System.Drawing.Imaging.ImageFormat.Jpeg)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Timer1.Stop()
        Timer2.Start()
        Button1.Visible = True
        Button3.Visible = False
    End Sub


End Class
