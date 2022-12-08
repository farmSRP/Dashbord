Imports PLClib
Imports System.Net.Http
Imports MetroFramework
Imports MetroFramework.Fonts
Imports System.Net.Sockets
Imports MySql.Data.MySqlClient
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Text

Public Class Form1

    Dim PLC As New PLClib.libPLC
    Dim Getbit() As String
    Dim getbit1() As String
    Dim getbit2() As String
    Dim getbit3() As String
    Dim GetDword() As String
    Dim GetSt1() As String
    Dim GetSt2() As String
    Dim GetSt3() As String

    Dim GetSt11() As String
    Dim GetSt22() As String
    Dim GetSt33() As String


    Dim GetDWword() As String
    Dim Str As String
    ' Dim Mysqlconn As MySqlConnection
    '  Dim cmd As MySqlCommand
    Dim st12() As String
    Dim st34() As String
    Dim ipsql1 As String
    Dim useridsql1 As String
    Dim passsql1 As String
    Dim database1 As String

    'loop time lamp Ready,RUN,STOP
    Dim i As Integer
    Dim i1 As Integer



    Dim linkFileData As String = "C:\Dashbord Patana Intercool\WindowsApp1\bin\Debug\data\"
    'chart1
    'data
    Dim chart1_dataColumn1 As Int32 = Int32.Parse(dataKeep_Show(linkFileData & "chart1\datachart1.txt"))
    Dim chart1_dataColumn2 As Int32 = Int32.Parse(dataKeep_Show(linkFileData & "chart1\datachart2.txt"))
    Dim chart1_dataColumn3 As Int32 = Int32.Parse(dataKeep_Show(linkFileData & "chart1\datachart3.txt"))
    Dim chart1_dataColumn4 As Int32 = Int32.Parse(dataKeep_Show(linkFileData & "chart1\datachart4.txt"))
    Dim chart1_dataColumn5 As Int32 = Int32.Parse(dataKeep_Show(linkFileData & "chart1\datachart5.txt"))

    'day
    Dim chart1_dayColumn1 As String = dataKeep_Show(linkFileData & "chart1\day1.txt")
    Dim chart1_dayColumn2 As String = dataKeep_Show(linkFileData & "chart1\day2.txt")
    Dim chart1_dayColumn3 As String = dataKeep_Show(linkFileData & "chart1\day3.txt")
    Dim chart1_dayColumn4 As String = dataKeep_Show(linkFileData & "chart1\day4.txt")

    Dim chart1_dataNow As Int32 = Int32.Parse(dataKeep_Show(linkFileData & "chart1\datachart5.txt"))
    Dim chart1_dayNow As String = DateTime.Now.ToString("dd/MM")

    Dim chart1_dayColumn5 As String = dataKeep_Show(linkFileData & "chart1\day5.txt")

    'chart2
    'data
    Dim chart2_dataColumn1 As Int32 = Int32.Parse(dataKeep_Show(linkFileData & "chart2\datachart1.txt"))
    Dim chart2_dataColumn2 As Int32 = Int32.Parse(dataKeep_Show(linkFileData & "chart2\datachart2.txt"))
    Dim chart2_dataColumn3 As Int32 = Int32.Parse(dataKeep_Show(linkFileData & "chart2\datachart3.txt"))
    Dim chart2_dataColumn4 As Int32 = Int32.Parse(dataKeep_Show(linkFileData & "chart2\datachart4.txt"))
    Dim chart2_dataColumn5 As Int32 = Int32.Parse(dataKeep_Show(linkFileData & "chart2\datachart5.txt"))

    'day
    Dim chart2_dayColumn1 As String = dataKeep_Show(linkFileData & "chart2\day1.txt")
    Dim chart2_dayColumn2 As String = dataKeep_Show(linkFileData & "chart2\day2.txt")
    Dim chart2_dayColumn3 As String = dataKeep_Show(linkFileData & "chart2\day3.txt")
    Dim chart2_dayColumn4 As String = dataKeep_Show(linkFileData & "chart2\day4.txt")

    Dim chart2_dataNow As Int32 = Int32.Parse(dataKeep_Show(linkFileData & "chart2\datachart5.txt"))
    Dim chart2_dayNow As String = DateTime.Now.ToString("dd/MM")

    Dim chart2_dayColumn5 As String = dataKeep_Show(linkFileData & "chart2\day5.txt")

    'chart3
    'data
    Dim chart3_dataColumn1 As Int32 = Int32.Parse(dataKeep_Show(linkFileData & "chart3\datachart1.txt"))
    Dim chart3_dataColumn2 As Int32 = Int32.Parse(dataKeep_Show(linkFileData & "chart3\datachart2.txt"))
    Dim chart3_dataColumn3 As Int32 = Int32.Parse(dataKeep_Show(linkFileData & "chart3\datachart3.txt"))
    Dim chart3_dataColumn4 As Int32 = Int32.Parse(dataKeep_Show(linkFileData & "chart3\datachart4.txt"))
    Dim chart3_dataColumn5 As Int32 = Int32.Parse(dataKeep_Show(linkFileData & "chart3\datachart5.txt"))

    'day
    Dim chart3_dayColumn1 As String = dataKeep_Show(linkFileData & "chart3\day1.txt")
    Dim chart3_dayColumn2 As String = dataKeep_Show(linkFileData & "chart3\day2.txt")
    Dim chart3_dayColumn3 As String = dataKeep_Show(linkFileData & "chart3\day3.txt")
    Dim chart3_dayColumn4 As String = dataKeep_Show(linkFileData & "chart3\day4.txt")

    Dim chart3_dataNow As Int32 = Int32.Parse(dataKeep_Show(linkFileData & "chart3\datachart5.txt"))
    Dim chart3_dayNow As String = DateTime.Now.ToString("dd/MM")

    Dim chart3_dayColumn5 As String = dataKeep_Show(linkFileData & "chart3\day5.txt")



    Dim readDataInPLC1 As Int32
    Dim readDataInPLC2 As Int32
    Dim readDataInPLC3 As Int32


    Dim strCheckFolder As String = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\"))

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function GetPrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function WritePrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Boolean

    End Function

    Private Function SetINI(ByVal strAppName As String, ByVal strKey As String, ByVal strValue As String, ByVal strFilePath As String) As Boolean
        SetINI = WritePrivateProfileString(strAppName, strKey, strValue, strFilePath)
    End Function

    Private Function GetINI(ByVal strAppName As String, ByVal strKey As String, ByVal strValue As String, ByVal strFilePath As String) As String

        Dim strbTmp As StringBuilder = New StringBuilder(255)
        GetPrivateProfileString(strAppName, strKey, strValue, strbTmp, strbTmp.Capacity, strFilePath)
        GetINI = strbTmp.ToString()

    End Function



    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label28.Text = DateTime.Now.ToString("dd/MM/yyyy")
        Label37.Text = DateTime.Now.ToString("HH:mm:ss")
        ' If Label37.Text = "03:32:00" Then
        'sql()
        ' sql2()
        ' sql3()
        '  End If


    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        'st1
        Dim PLAN = GetINI("st1", "PLAN", "", strCheckFolder + "\Nwm.dll")
        Dim ACTUAL = GetINI("st1", "ACTUAL", "", strCheckFolder + "\Nwm.dll")
        Dim num1 = GetINI("st1", "num1", "", strCheckFolder + "\Nwm.dll")
        Dim num2 = GetINI("st1", "num2", "", strCheckFolder + "\Nwm.dll")
        'st2
        Dim PLAN2 = GetINI("st2", "PLAN2", "", strCheckFolder + "\Nwm.dll")
        Dim ACTUAL2 = GetINI("st2", "ACTUAL2", "", strCheckFolder + "\Nwm.dll")
        Dim num3 = GetINI("st2", "num3", "", strCheckFolder + "\Nwm.dll")
        Dim num4 = GetINI("st2", "num4", "", strCheckFolder + "\Nwm.dll")
        'st3
        Dim PLAN3 = GetINI("st3", "PLAN3", "", strCheckFolder + "\Nwm.dll")
        Dim ACTUAL3 = GetINI("st3", "ACTUAL3", "", strCheckFolder + "\Nwm.dll")
        Dim num5 = GetINI("st3", "num5", "", strCheckFolder + "\Nwm.dll")
        Dim num6 = GetINI("st3", "num6", "", strCheckFolder + "\Nwm.dll")




        Dim PLAN1 = GetINI("st11", "PLAN1", "", strCheckFolder + "\Nwm.dll")
        Dim ACTUAL1 = GetINI("st11", "ACTUAL1", "", strCheckFolder + "\Nwm.dll")
        Dim num11 = GetINI("st11", "num11", "", strCheckFolder + "\Nwm.dll")
        Dim num21 = GetINI("st11", "num21", "", strCheckFolder + "\Nwm.dll")
        'st2
        Dim PLAN22 = GetINI("st22", "PLAN22", "", strCheckFolder + "\Nwm.dll")
        Dim ACTUAL22 = GetINI("st22", "ACTUAL22", "", strCheckFolder + "\Nwm.dll")
        Dim num32 = GetINI("st22", "num32", "", strCheckFolder + "\Nwm.dll")
        Dim num42 = GetINI("st22", "num42", "", strCheckFolder + "\Nwm.dll")
        'st3
        Dim PLAN33 = GetINI("st33", "PLAN33", "", strCheckFolder + "\Nwm.dll")
        Dim ACTUAL33 = GetINI("st33", "ACTUAL33", "", strCheckFolder + "\Nwm.dll")
        Dim num53 = GetINI("st33", "num53", "", strCheckFolder + "\Nwm.dll")
        Dim num63 = GetINI("st33", "num63", "", strCheckFolder + "\Nwm.dll")





        Dim D10 = GetINI("DATAD", "DATAD1", "", strCheckFolder + "\Nwm.dll")
        Dim D11 = GetINI("DATAD", "DATANUM11", "", strCheckFolder + "\Nwm.dll")
        Dim D12 = GetINI("DATAD", "DATANUM12", "", strCheckFolder + "\Nwm.dll")


        Dim D20 = GetINI("DATAD", "DATAD2", "", strCheckFolder + "\Nwm.dll")
        Dim D21 = GetINI("DATAD", "DATANUM21", "", strCheckFolder + "\Nwm.dll")
        Dim D22 = GetINI("DATAD", "DATANUM21", "", strCheckFolder + "\Nwm.dll")


        Dim D30 = GetINI("DATAD", "DATAD3", "", strCheckFolder + "\Nwm.dll")
        Dim D31 = GetINI("DATAD", "DATANUM32", "", strCheckFolder + "\Nwm.dll")
        Dim D32 = GetINI("DATAD", "DATANUM32", "", strCheckFolder + "\Nwm.dll")



        'NAMEST
        Dim nameST1 = GetINI("nameST", "st1", "", strCheckFolder + "\Nwm.dll")
        Dim nameST2 = GetINI("nameST", "st2", "", strCheckFolder + "\Nwm.dll")
        Dim nameST3 = GetINI("nameST", "st3", "", strCheckFolder + "\Nwm.dll")


        'namest
        title1.Text = nameST1
        title2.Text = nameST2
        title3.Text = nameST3

        ''plan st1 st2 st3
        ''st1
        'inprocess_1.Text = PLAN
        ''st2
        'inprocess_2.Text = PLAN2
        ''st3
        'inprocess_3.Text = PLAN3



        If PLC.IsConnected = True Then
            ' GetDword = PLC.WordRead("C", 10, 2) 'รับค่าจาก ดีไวน์ของPLC "C"คือ memory ดีไวน์ 10,2
            ' GetDWword = PLC.WordRead("D", 0, 2) 'รับค่าจาก ดีไวน์ของPLC "C"คือ memory ดีไวน์ 0,2
            ' Getbit = PLC.BitRead("M", 0, 2) 'รับค่าจาก ดีไวน์ของPLC "C"คือ memory ดีไวน์ 0,2
            getbit1 = PLC.BitRead(D10, D11, D12) 'รับค่าจาก ดีไวน์ของPLC "C"คือ memory ดีไวน์ 3,4
            getbit2 = PLC.BitRead(D20, D21, D22)
            getbit3 = PLC.BitRead(D30, D31, D32)

            GetSt1 = PLC.WordRead("D", 750, 1)  'D1 ,D2
            GetSt2 = PLC.WordRead("D", 1000, 1)  'D2 ,D3
            GetSt3 = PLC.WordRead("D", 1600, 1)  'D4 ,D5

            GetSt11 = PLC.WordRead("D", 1000, 1)  'D1 ,D2
            GetSt22 = PLC.WordRead("D", 1200, 1)  'D2 ,D3
            GetSt33 = PLC.WordRead("D", 1700, 1)
            ' st12 = PLC.WordRead("C", 5, 6) 'รับค่าดีไว
            ' st34 = PLC.WordRead("C", 7, 8) 'รับค่าดีไว


        End If
        If PLC.LastErrorCode = 0 Then
            'st1 D1
            input_1.Text = GetSt1(0) 'นำค่าดีไวน์มาแสดงที่ label19
            output_1.Text = GetSt11(0)
            readDataInPLC1 = GetSt11(0)
            'st2 D3
            input_2.Text = GetSt2(0) 'นำค่าดีไวน์มาแสดงที่ label9
            output_2.Text = GetSt22(0)
            readDataInPLC2 = GetSt22(0)
            'st3 D5
            input_3.Text = GetSt3(0) 'นำค่าดีไวน์มาแสดงที่ label26
            output_3.Text = GetSt33(0)
            readDataInPLC3 = GetSt33(0)

            ' TextBox1.Text = GetDword(0)
            ' TextBox2.Text = GetDword(1)
            ' Label10.Text = GetDword(0)
            Dim st111 = getbit1(0)
            Dim st222 = getbit2(0)
            Dim st333 = getbit3(0)


            '    ''ST1
            '    'If st111 = 1 Then
            '    '    PictureBox7.BackColor = Color.Lime
            '    '    Label33.Text = "RUN"
            '    'ElseIf st111 = 0 Then
            '    '    PictureBox7.BackColor = Color.Black
            '    '    Label33.Text = "Ready"
            '    'End If

            '    ''ST2
            '    'If st222 = 1 Then
            '    '    PictureBox3.BackColor = Color.Lime
            '    '    Label31.Text = "RUN"
            '    'ElseIf st222 = 0 Then
            '    '    PictureBox3.BackColor = Color.Black
            '    '    Label31.Text = "Ready"
            '    'End If

            '    ''ST3
            '    'If st333 = 1 Then
            '    '    PictureBox5.BackColor = Color.Lime
            '    '    Label29.Text = "RUN"
            '    'ElseIf st333 = 0 Then
            '    '    PictureBox5.BackColor = Color.Black
            '    '    Label29.Text = "Ready"
            '    'End If

        End If
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick

        'ST1
        inprocess_1.Text = input_1.Text - output_1.Text  'คำนวณ DIFF.

        'ST2
        inprocess_2.Text = input_2.Text - output_2.Text 'คำนวณ DIFF.

        'ST3
        inprocess_3.Text = input_3.Text - output_3.Text 'คำนวณ DIFF.

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        '  i += 1
        ' If i = 10 Then
        ' PictureBox3.BackColor = Color.Black
        ' Label31.Text = "Ready"
        ' PictureBox7.BackColor = Color.Black
        ' Label33.Text = "Ready"
        ' PictureBox5.BackColor = Color.Black
        ' Label29.Text = "Ready"
        ' ElseIf i = 20 Then
        ' PictureBox3.BackColor = Color.Lime
        'Label31.Text = "RUN"
        ' PictureBox7.BackColor = Color.Lime
        ' Label33.Text = "RUN"
        'PictureBox5.BackColor = Color.Lime
        ' Label29.Text = "RUN"
        'i = 0

        '  End If
    End Sub



    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        '  i1 += 1
        ' If i1 = 10 Then
        '  PictureBox4.BackColor = Color.Black
        '  Label32.ForeColor = Color.Black
        '     PictureBox6.BackColor = Color.Black
        '  Label30.ForeColor = Color.Black
        ' PictureBox8.BackColor = Color.Black
        '  Label34.ForeColor = Color.Black
        ' ElseIf i1 = 20 Then
        ' PictureBox4.BackColor = Color.Red
        ' Label32.ForeColor = Color.Red
        ' PictureBox6.BackColor = Color.Red
        ' Label30.ForeColor = Color.Red
        ' PictureBox8.BackColor = Color.Red
        ' Label34.ForeColor = Color.Red
        ' i1 = 0

        '  End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        chart1_dayUpdate()
        chart2_dayUpdate()
        chart3_dayUpdate()

        dataCharts.Start()


        'Label32.ForeColor = Color.Black
        'Label30.ForeColor = Color.Black
        'Label34.ForeColor = Color.Black

        'Label13.Text = ""
        'Label24.Text = ""

        'Label8.Text = ""
        'Label4.Text = ""

        'Label21.Text = ""
        'Label20.Text = ""
        Label38.Text = ""


        'st1
        inprocess_1.Text = "0000"
        input_1.Text = "0000"
        output_1.Text = "0000"
        ' Dim efficency As String = Label1.Text

        'st2
        output_2.Text = "0000"
        input_2.Text = "0000"
        inprocess_2.Text = "0000"
        'Dim efficency2 As String = Label1.Text

        'st3
        output_3.Text = "0000"
        input_3.Text = "0000"
        inprocess_3.Text = "0000"


        Dim ip = GetINI("confignwm", "IP", "", strCheckFolder + "\Nwm.dll")
        Dim port = GetINI("confignwm", "PORT", "", strCheckFolder + "\Nwm.dll")
        'My.Computer.Registry.CurrentUser.DeleteSubKey("SOFTWARE\Code")

        'model
        Dim model = GetINI("model", "model", "", strCheckFolder + "\Nwm.dll")
        'model
        'Label36.Text = model


        Dim NAMEST001 = GetINI("NAMEST11", "NAMEST001", "", strCheckFolder + "\Nwm.dll")
        Dim NAMEST002 = GetINI("NAMEST11", "NAMEST002", "", strCheckFolder + "\Nwm.dll")
        Dim NAMEST003 = GetINI("NAMEST11", "NAMEST003", "", strCheckFolder + "\Nwm.dll")


        title1.Text = NAMEST001
        title2.Text = NAMEST002
        title3.Text = NAMEST003

        If My.Computer.Network.Ping(ip, port) Then

            If PLC.IsConnected = False Then
                PLC.Connect(ip, port) 'ip PLC config SLMP ด้วยไอพีที่PLC เจอ ตอนแรก
                If PLC.IsConnected = True Then
                    '  La_Status.Text = "Connect"
                    '   La_Status.ForeColor = Color.Green

                    '   Label38.Text = "ONLINE"
                    '  Label38.ForeColor = Color.Lime
                    Timer4.Start()
                    'conn()
                    My.Computer.Registry.CurrentUser.DeleteSubKey("SOFTWARE\Code")
                End If
            End If
        Else
            MsgBox("ไม่พบการเชื่อมต่อกับPLCหรือเกิดปัญหาลองตรวจสอบการเชื่อมต่ออีกครั้ง ปิดโปรแกรมและเปิดใหม่อีกครั้ง")

            ' Me.Close()
            '  Timer6.Start()

        End If
    End Sub
    Sub conn()
        If PLC.IsConnected = True Then
            ' GetDword = PLC.WordRead("C", 10, 2) 'รับค่าจาก ดีไวน์ของPLC "C"คือ memory ดีไวน์ 10,2
            ' GetDWword = PLC.WordRead("D", 0, 2) 'รับค่าจาก ดีไวน์ของPLC "C"คือ memory ดีไวน์ 0,2
            ' Getbit = PLC.BitRead("M", 0, 2) 'รับค่าจาก ดีไวน์ของPLC "C"คือ memory ดีไวน์ 0,2
            getbit1 = PLC.BitRead("M", 1, 88) 'รับค่าจาก ดีไวน์ของPLC "C"คือ memory ดีไวน์ 3,4
            getbit2 = PLC.BitRead("M", 101, 78)
            getbit3 = PLC.BitRead("M", 102, 99)
            GetSt1 = PLC.WordRead("D", 5000, 2)  'D1 ,D2
            GetSt2 = PLC.WordRead("C", 100, 14)  'D2 ,D3
            GetSt3 = PLC.WordRead("C", 101, 13)  'D4 ,D5

            ' st12 = PLC.WordRead("C", 5, 6) 'รับค่าดีไว
            ' st34 = PLC.WordRead("C", 7, 8) 'รับค่าดีไว
        End If
        If PLC.LastErrorCode = 0 Then
            'st1 D1
            input_1.Text = GetSt1(0) 'นำค่าดีไวน์มาแสดงที่ label19

            'st2 D3
            input_2.Text = GetSt2(0) 'นำค่าดีไวน์มาแสดงที่ label9
            'st3 D5
            input_3.Text = GetSt3(0) 'นำค่าดีไวน์มาแสดงที่ label26


            ' TextBox1.Text = GetDword(0)
            ' TextBox2.Text = GetDword(1)
            ' Label10.Text = GetDword(0)
            Dim st111 = getbit1(0)
            Dim st222 = getbit2(0)
            Dim st333 = getbit3(0)


            'ST1
            'If st111 = 1 Then
            '    PictureBox7.BackColor = Color.Lime
            '    Label33.Text = "RUN"
            'ElseIf st111 = 0 Then
            '    PictureBox7.BackColor = Color.Black
            '    Label33.Text = "Ready"
            'End If

            ''ST2
            'If st222 = 1 Then
            '    PictureBox3.BackColor = Color.Lime
            '    Label31.Text = "RUN"
            'ElseIf st222 = 0 Then
            '    PictureBox3.BackColor = Color.Black
            '    Label31.Text = "Ready"
            'End If

            ''ST3
            'If st333 = 1 Then
            '    PictureBox5.BackColor = Color.Lime
            '    Label29.Text = "RUN"
            'ElseIf st333 = 0 Then
            '    PictureBox5.BackColor = Color.Black
            '    Label29.Text = "Ready"
            'End If

        End If
    End Sub
    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles Timer6.Tick
        ' i += 1
        '  If i = 1 Then
        '  Label38.Text = "OFFLINE"
        '  Label38.ForeColor = Color.Red
        '  ElseIf i = 2 Then
        ' Label38.ForeColor = Color.Black
        ' i = 0


        '  End If
        '  i1 += 1
        '  If i1 = 20 Then
        'Me.Close()
        '
        '  End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Shell("shutdown -s -t 1")

    End Sub


    Private Sub Timer7_Tick(sender As Object, e As EventArgs) Handles Timer7.Tick

    End Sub

    Private Sub Label35_Click(sender As Object, e As EventArgs) Handles Label35.Click
        Dim message, title As String
        Dim myValue As String


        message = "Please input your Mobel Name."
        title = "Mobel NAME: Input"
        myValue = InputBox(message, title, Label36.Text)

        Label36.Text = myValue
    End Sub




    Private Sub dataKeep_new(fileLocal As String, dataKeep As Int32)
        Dim file As System.IO.StreamWriter
        Dim filePath As String = fileLocal
        Dim fileDelete As System.IO.File
        If fileDelete.Exists(filePath) Then
            fileDelete.Delete(filePath)
        End If

        file = My.Computer.FileSystem.OpenTextFileWriter(fileLocal, True)
        file.WriteLine(dataKeep.ToString())
        file.Close()
    End Sub

    Private Sub dayKeep_new(fileLocal As String, dataKeep As String)
        Dim file As System.IO.StreamWriter
        Dim filePath As String = fileLocal
        Dim fileDelete As System.IO.File
        If fileDelete.Exists(filePath) Then
            fileDelete.Delete(filePath)
        End If

        file = My.Computer.FileSystem.OpenTextFileWriter(fileLocal, True)
        file.WriteLine(dataKeep)
        file.Close()
    End Sub

    Private Function dataKeep_Show(fileLocal As String) As String
        Dim line As String
        Using reader As StreamReader = New StreamReader(fileLocal, True)
            line = reader.ReadLine()
        End Using

        Return line.ToString()
    End Function


    Private Sub updateDataChart1()
        Chart1.Series(0).Points.AddXY(chart1_dayColumn1, chart1_dataColumn1)
        Chart1.Series(0).Points.AddXY(chart1_dayColumn2, chart1_dataColumn2)
        Chart1.Series(0).Points.AddXY(chart1_dayColumn3, chart1_dataColumn3)
        Chart1.Series(0).Points.AddXY(chart1_dayColumn4, chart1_dataColumn4)
        Chart1.Series(0).Points.AddXY(chart1_dayColumn5, chart1_dataColumn5)
    End Sub

    Private Sub updateDataChart2()
        Chart2.Series(0).Points.AddXY(chart2_dayColumn1, chart2_dataColumn1)
        Chart2.Series(0).Points.AddXY(chart2_dayColumn2, chart2_dataColumn2)
        Chart2.Series(0).Points.AddXY(chart2_dayColumn3, chart2_dataColumn3)
        Chart2.Series(0).Points.AddXY(chart2_dayColumn4, chart2_dataColumn4)
        Chart2.Series(0).Points.AddXY(chart2_dayColumn5, chart2_dataColumn5)
    End Sub

    Private Sub updateDataChart3()
        Chart3.Series(0).Points.AddXY(chart3_dayColumn1, chart3_dataColumn1)
        Chart3.Series(0).Points.AddXY(chart3_dayColumn2, chart3_dataColumn2)
        Chart3.Series(0).Points.AddXY(chart3_dayColumn3, chart3_dataColumn3)
        Chart3.Series(0).Points.AddXY(chart3_dayColumn4, chart3_dataColumn4)
        Chart3.Series(0).Points.AddXY(chart3_dayColumn5, chart3_dataColumn5)
    End Sub

    Private Sub dataCharts_Tick(sender As Object, e As EventArgs) Handles dataCharts.Tick

        'chart1
        chart1_dayNow = DateTime.Now.ToString("dd/MM")
        chart1_dataColumn5 = readDataInPLC1

        If chart1_dataNow <> chart1_dataColumn5 Then
            chart1_dataNow = chart1_dataColumn5
            dataKeep_new(linkFileData & "chart1\datachart5.txt", chart1_dataColumn5)
            Chart1.Series(0).Points.Clear()
            updateDataChart1()
        End If

        If chart1_dayNow <> chart1_dayColumn5 Then
            Chart1.Series(0).Points.Clear()

            chart1_dataColumn1 = chart1_dataColumn2
            chart1_dataColumn2 = chart1_dataColumn3
            chart1_dataColumn3 = chart1_dataColumn4
            chart1_dataColumn4 = chart1_dataColumn5
            chart1_dataColumn5 = readDataInPLC1

            chart1_dayColumn1 = chart1_dayColumn2
            chart1_dayColumn2 = chart1_dayColumn3
            chart1_dayColumn3 = chart1_dayColumn4
            chart1_dayColumn4 = chart1_dayColumn5
            chart1_dayColumn5 = chart1_dayNow

            dataKeep_new(linkFileData & "chart1\datachart1.txt", chart1_dataColumn1)
            dataKeep_new(linkFileData & "chart1\datachart2.txt", chart1_dataColumn2)
            dataKeep_new(linkFileData & "chart1\datachart3.txt", chart1_dataColumn3)
            dataKeep_new(linkFileData & "chart1\datachart4.txt", chart1_dataColumn4)
            dataKeep_new(linkFileData & "chart1\datachart5.txt", chart1_dataColumn5)

            dayKeep_new(linkFileData & "chart1\day1.txt", chart1_dayColumn1)
            dayKeep_new(linkFileData & "chart1\day2.txt", chart1_dayColumn2)
            dayKeep_new(linkFileData & "chart1\day3.txt", chart1_dayColumn3)
            dayKeep_new(linkFileData & "chart1\day4.txt", chart1_dayColumn4)
            dayKeep_new(linkFileData & "chart1\day5.txt", chart1_dayColumn5)

            updateDataChart1()
        End If


        'chart2
        chart2_dayNow = DateTime.Now.ToString("dd/MM")
        chart2_dataColumn5 = readDataInPLC2

        If chart2_dataNow <> chart2_dataColumn5 Then
            chart2_dataNow = chart2_dataColumn5
            dataKeep_new(linkFileData & "chart2\datachart5.txt", chart2_dataColumn5)
            Chart2.Series(0).Points.Clear()
            updateDataChart2()
        End If

        If chart2_dayNow <> chart2_dayColumn5 Then
            Chart2.Series(0).Points.Clear()

            chart2_dataColumn1 = chart2_dataColumn2
            chart2_dataColumn2 = chart2_dataColumn3
            chart2_dataColumn3 = chart2_dataColumn4
            chart2_dataColumn4 = chart2_dataColumn5
            chart2_dataColumn5 = readDataInPLC2

            chart2_dayColumn1 = chart2_dayColumn2
            chart2_dayColumn2 = chart2_dayColumn3
            chart2_dayColumn3 = chart2_dayColumn4
            chart2_dayColumn4 = chart2_dayColumn5
            chart2_dayColumn5 = chart2_dayNow

            dataKeep_new(linkFileData & "chart2\datachart1.txt", chart2_dataColumn1)
            dataKeep_new(linkFileData & "chart2\datachart2.txt", chart2_dataColumn2)
            dataKeep_new(linkFileData & "chart2\datachart3.txt", chart2_dataColumn3)
            dataKeep_new(linkFileData & "chart2\datachart4.txt", chart2_dataColumn4)
            dataKeep_new(linkFileData & "chart2\datachart5.txt", chart2_dataColumn5)

            dayKeep_new(linkFileData & "chart2\day1.txt", chart2_dayColumn1)
            dayKeep_new(linkFileData & "chart2\day2.txt", chart2_dayColumn2)
            dayKeep_new(linkFileData & "chart2\day3.txt", chart2_dayColumn3)
            dayKeep_new(linkFileData & "chart2\day4.txt", chart2_dayColumn4)
            dayKeep_new(linkFileData & "chart2\day5.txt", chart2_dayColumn5)

            updateDataChart2()
        End If

        'chart3
        chart3_dayNow = DateTime.Now.ToString("dd/MM")
        chart3_dataColumn5 = readDataInPLC3

        If chart3_dataNow <> chart3_dataColumn5 Then
            chart3_dataNow = chart3_dataColumn5
            dataKeep_new(linkFileData & "chart3\datachart5.txt", chart3_dataColumn5)
            Chart3.Series(0).Points.Clear()
            updateDataChart3()
        End If

        If chart3_dayNow <> chart3_dayColumn5 Then
            Chart3.Series(0).Points.Clear()

            chart3_dataColumn1 = chart3_dataColumn2
            chart3_dataColumn2 = chart3_dataColumn3
            chart3_dataColumn3 = chart3_dataColumn4
            chart3_dataColumn4 = chart3_dataColumn5
            chart3_dataColumn5 = readDataInPLC3

            chart3_dayColumn1 = chart3_dayColumn2
            chart3_dayColumn2 = chart3_dayColumn3
            chart3_dayColumn3 = chart3_dayColumn4
            chart3_dayColumn4 = chart3_dayColumn5
            chart3_dayColumn5 = chart3_dayNow

            dataKeep_new(linkFileData & "chart3\datachart1.txt", chart3_dataColumn1)
            dataKeep_new(linkFileData & "chart3\datachart2.txt", chart3_dataColumn2)
            dataKeep_new(linkFileData & "chart3\datachart3.txt", chart3_dataColumn3)
            dataKeep_new(linkFileData & "chart3\datachart4.txt", chart3_dataColumn4)
            dataKeep_new(linkFileData & "chart3\datachart5.txt", chart3_dataColumn5)

            dayKeep_new(linkFileData & "chart3\day1.txt", chart3_dayColumn1)
            dayKeep_new(linkFileData & "chart3\day2.txt", chart3_dayColumn2)
            dayKeep_new(linkFileData & "chart3\day3.txt", chart3_dayColumn3)
            dayKeep_new(linkFileData & "chart3\day4.txt", chart3_dayColumn4)
            dayKeep_new(linkFileData & "chart3\day5.txt", chart3_dayColumn5)

            updateDataChart3()
        End If

    End Sub

    Private Sub chart1_dayUpdate()

        If chart1_dayNow <> chart1_dayColumn5 Then
            Chart1.Series(0).Points.Clear()

            chart1_dataColumn1 = chart1_dataColumn2
            chart1_dataColumn2 = chart1_dataColumn3
            chart1_dataColumn3 = chart1_dataColumn4
            chart1_dataColumn4 = chart1_dataColumn5
            chart1_dataColumn5 = readDataInPLC1

            chart1_dayColumn1 = chart1_dayColumn2
            chart1_dayColumn2 = chart1_dayColumn3
            chart1_dayColumn3 = chart1_dayColumn4
            chart1_dayColumn4 = chart1_dayColumn5
            chart1_dayColumn5 = chart1_dayNow

            dataKeep_new(linkFileData & "chart1\datachart1.txt", chart1_dataColumn1)
            dataKeep_new(linkFileData & "chart1\datachart2.txt", chart1_dataColumn2)
            dataKeep_new(linkFileData & "chart1\datachart3.txt", chart1_dataColumn3)
            dataKeep_new(linkFileData & "chart1\datachart4.txt", chart1_dataColumn4)
            dataKeep_new(linkFileData & "chart1\datachart5.txt", chart1_dataColumn5)

            dayKeep_new(linkFileData & "chart1\day1.txt", chart1_dayColumn1)
            dayKeep_new(linkFileData & "chart1\day2.txt", chart1_dayColumn2)
            dayKeep_new(linkFileData & "chart1\day3.txt", chart1_dayColumn3)
            dayKeep_new(linkFileData & "chart1\day4.txt", chart1_dayColumn4)
            dayKeep_new(linkFileData & "chart1\day5.txt", chart1_dayColumn5)

            updateDataChart1()
        Else
            updateDataChart1()
        End If

    End Sub

    Private Sub chart2_dayUpdate()
        If chart2_dayNow <> chart2_dayColumn5 Then
            Chart2.Series(0).Points.Clear()

            chart2_dataColumn1 = chart2_dataColumn2
            chart2_dataColumn2 = chart2_dataColumn3
            chart2_dataColumn3 = chart2_dataColumn4
            chart2_dataColumn4 = chart2_dataColumn5
            chart2_dataColumn5 = readDataInPLC1

            chart2_dayColumn1 = chart2_dayColumn2
            chart2_dayColumn2 = chart2_dayColumn3
            chart2_dayColumn3 = chart2_dayColumn4
            chart2_dayColumn4 = chart2_dayColumn5
            chart2_dayColumn5 = chart2_dayNow

            dataKeep_new(linkFileData & "chart2\datachart1.txt", chart2_dataColumn1)
            dataKeep_new(linkFileData & "chart2\datachart2.txt", chart2_dataColumn2)
            dataKeep_new(linkFileData & "chart2\datachart3.txt", chart2_dataColumn3)
            dataKeep_new(linkFileData & "chart2\datachart4.txt", chart2_dataColumn4)
            dataKeep_new(linkFileData & "chart2\datachart5.txt", chart2_dataColumn5)

            dayKeep_new(linkFileData & "chart2\day1.txt", chart2_dayColumn1)
            dayKeep_new(linkFileData & "chart2\day2.txt", chart2_dayColumn2)
            dayKeep_new(linkFileData & "chart2\day3.txt", chart2_dayColumn3)
            dayKeep_new(linkFileData & "chart2\day4.txt", chart2_dayColumn4)
            dayKeep_new(linkFileData & "chart2\day5.txt", chart2_dayColumn5)

            updateDataChart2()
        Else
            updateDataChart2()
        End If

    End Sub

    Private Sub chart3_dayUpdate()
        If chart3_dayNow <> chart3_dayColumn5 Then
            Chart3.Series(0).Points.Clear()

            chart3_dataColumn1 = chart3_dataColumn2
            chart3_dataColumn2 = chart3_dataColumn3
            chart3_dataColumn3 = chart3_dataColumn4
            chart3_dataColumn4 = chart3_dataColumn5
            chart3_dataColumn5 = readDataInPLC3

            chart3_dayColumn1 = chart3_dayColumn2
            chart3_dayColumn2 = chart3_dayColumn3
            chart3_dayColumn3 = chart3_dayColumn4
            chart3_dayColumn4 = chart3_dayColumn5
            chart3_dayColumn5 = chart3_dayNow

            dataKeep_new(linkFileData & "chart3\datachart1.txt", chart3_dataColumn1)
            dataKeep_new(linkFileData & "chart3\datachart2.txt", chart3_dataColumn2)
            dataKeep_new(linkFileData & "chart3\datachart3.txt", chart3_dataColumn3)
            dataKeep_new(linkFileData & "chart3\datachart4.txt", chart3_dataColumn4)
            dataKeep_new(linkFileData & "chart3\datachart5.txt", chart3_dataColumn5)

            dayKeep_new(linkFileData & "chart3\day1.txt", chart3_dayColumn1)
            dayKeep_new(linkFileData & "chart3\day2.txt", chart3_dayColumn2)
            dayKeep_new(linkFileData & "chart3\day3.txt", chart3_dayColumn3)
            dayKeep_new(linkFileData & "chart3\day4.txt", chart3_dayColumn4)
            dayKeep_new(linkFileData & "chart3\day5.txt", chart3_dayColumn5)

            updateDataChart3()
        Else
            updateDataChart3()
        End If

    End Sub

    Private Sub Form1_DoubleClick(sender As Object, e As EventArgs) Handles Panel3.DoubleClick, Panel2.DoubleClick, Panel1.DoubleClick, MyBase.DoubleClick, Chart3.DoubleClick, Chart2.DoubleClick, Chart1.DoubleClick
        Dim message, title As String
        Dim myValue As String


        message = "Please input your Mobel Name."
        title = "Mobel NAME: Input"
        myValue = InputBox(message, title, Label36.Text)

        Label36.Text = myValue
    End Sub

End Class
