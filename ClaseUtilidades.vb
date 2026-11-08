Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Microsoft.Office.Interop
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms

Public Class ClaseUtilidades

    ' Método para obtener datos
    Public Shared Function ObtenerDatos(query As String) As DataTable
        Dim dt As New DataTable
        Dim connectionString As String = My.Settings.BD
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Using cmd As New SqlCommand(query, conn)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    ' Método para exportar según configuración
    Public Shared Sub ExportarAutomatico(dgv As DataGridView, tipoReporte As String)
        Dim formatoExportacion As String = My.Settings.FormatoExportacion

        ' Formatear la fecha como dd_MM_yyyy
        Dim fechaDescarga As String = DateTime.Now.ToString("dd_MM_yyyy")
        Dim fileName As String = $"{tipoReporte}_{fechaDescarga}"

        ' Usar un cuadro de diálogo para elegir la carpeta de destino
        Using folderDialog As New FolderBrowserDialog()
            If folderDialog.ShowDialog() = DialogResult.OK Then
                Dim folderPath As String = folderDialog.SelectedPath
                Select Case formatoExportacion
                    Case "Excel"
                        ExportarDataGridView(dgv, Path.Combine(folderPath, fileName & ".xlsx"))
                    Case "PDF"
                        ExportarPDF(dgv, Path.Combine(folderPath, fileName & ".pdf"))
                    Case Else
                        MessageBox.Show("El formato configurado no es válido. Cambie la configuración.", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Select
            End If
        End Using
    End Sub

    ' Método para exportar a Excel
    Public Shared Sub ExportarDataGridView(dgv As DataGridView, fileName As String)
        Dim excelApp As New Excel.Application
        Dim workbook = excelApp.Workbooks.Add()
        Dim sheet = workbook.Sheets(1)
        ' Agregar encabezado
        sheet.Cells(1, 1).Value = "Tipo de Reporte: " & fileName
        sheet.Cells(2, 1).Value = "Fecha de Exportación: " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        sheet.Cells(4, 1).Value = "Reporte de Datos"
        sheet.Cells(5, 1).Value = "---------------------------------------------------"

        ' Agregar títulos de columnas
        For i = 1 To dgv.Columns.Count
            sheet.Cells(6, i).Value = dgv.Columns(i - 1).HeaderText
        Next

        ' Agregar datos de la DataGridView
        For i = 0 To dgv.Rows.Count - 1
            For j = 0 To dgv.Columns.Count - 1
                sheet.Cells(i + 7, j + 1).Value = dgv.Rows(i).Cells(j).Value
            Next
        Next

        ' Ajustar formato de las columnas
        sheet.Columns.AutoFit()

        ' Guardar archivo
        workbook.SaveAs(fileName)
        workbook.Close()
        excelApp.Quit()

        MessageBox.Show("Exportación completada en Excel: " & fileName)
    End Sub

    ' Método para exportar a PDF
    Public Shared Sub ExportarPDF(dgv As DataGridView, fileName As String)
        Dim doc As New Document()
        PdfWriter.GetInstance(doc, New FileStream(fileName, FileMode.Create))
        doc.Open()

        Dim nombreArchivo As String = Path.GetFileName(fileName)
        ' Agregar encabezado
        doc.Add(New Paragraph("Tipo de Reporte: " & nombreArchivo)) ' Solo el tipo de reporte
        doc.Add(New Paragraph("Fecha de Exportación: " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")))
        doc.Add(New Paragraph("Reporte de Datos"))
        doc.Add(New Paragraph("---------------------------------------------------"))
        doc.Add(New Paragraph(" "))

        ' Crear tabla para los datos
        Dim table As New PdfPTable(dgv.Columns.Count)

        ' Agregar encabezado de columnas
        For Each column As DataGridViewColumn In dgv.Columns
            table.AddCell(New Phrase(column.HeaderText))
        Next

        ' Agregar datos de las filas
        For Each row As DataGridViewRow In dgv.Rows
            If Not row.IsNewRow Then
                For Each cell As DataGridViewCell In row.Cells
                    table.AddCell(If(cell.Value Is Nothing, "", cell.Value.ToString()))
                Next
            End If
        Next

        doc.Add(table)
        doc.Close()

        MessageBox.Show("Exportación completada en PDF: " & fileName)
    End Sub


End Class
