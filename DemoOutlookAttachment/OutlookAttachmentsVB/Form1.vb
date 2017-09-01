Option Strict On

Imports System.IO
Imports System.Linq
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop.Outlook

Public Class Form1

    Private ReadOnly mobjApplication As New Application

    ''' <summary>
    ''' Handle the DragOver event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Label1_DragOver(ByVal sender As Object, ByVal e As DragEventArgs) Handles Label1.DragOver
        If e.Data.GetDataPresent("FileGroupDescriptor") Then
            'handle a message dragged from Outllok
            e.Effect = DragDropEffects.Copy
        Else
            'otherwise, do not handle
            e.Effect = DragDropEffects.None
        End If
    End Sub

    ''' <summary>
    ''' Handle the DragDrop event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Label1_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles Label1.DragDrop
        lstResults.Items.Clear()
        Try
            If e.Data.GetDataPresent("FileGroupDescriptor") Then
                'supports a drop of a Outlook message
                For Each objMi As MailItem In mobjApplication.ActiveExplorer.Selection()
                    'hardcode a destination path for testing
                    Dim strFile As String = Path.Combine("c:\temp", FixFileName(objMi.Subject + "_" + objMi.SenderEmailAddress + ".msg"))
                    lstResults.Items.Add(strFile)
                    objMi.SaveAs(strFile)
                    GetAttachmentsInfo(objMi)
                Next
            End If

        Catch ex As System.Exception
            lstResults.Items.Add("An error occured in the drop event")
            lstResults.Items.Add(ex.ToString)
        End Try
    End Sub

    Private Sub GetAttachmentsInfo(ByVal pMailItem As MailItem)
        If Not IsNothing(pMailItem.Attachments) Then
            For i As Integer = 1 To pMailItem.Attachments.Count
                Dim currentAttachment As Attachment = pMailItem.Attachments.Item(i)
                If Not IsNothing(currentAttachment) Then
                    lstResults.Items.Add("attachment #" + i.ToString())
                    lstResults.Items.Add("File Name: " + currentAttachment.FileName)
                    Dim strFile As String = Path.Combine("c:\temp", FixFileName(currentAttachment.FileName))
                    currentAttachment.SaveAsFile(strFile)
                    Marshal.ReleaseComObject(currentAttachment)
                End If
            Next
        End If
    End Sub

    Private Function FixFileName(ByVal pFileName As String) As String
        Dim invalidChars As Char() = Path.GetInvalidFileNameChars()
        If (pFileName.IndexOfAny(invalidChars) >= 0) Then
            pFileName = invalidChars.Aggregate(pFileName, Function(current, invalidChar) current.Replace(invalidChar, Convert.ToChar("_")))
        End If
        Return pFileName
    End Function

End Class
