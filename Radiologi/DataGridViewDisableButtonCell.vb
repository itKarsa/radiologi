Imports System.Windows.Forms.VisualStyles

Public Class DataGridViewDisableButtonCell
    Inherits DataGridViewButtonCell

    Private enabledValue As Boolean
    Public Property Enabled As Boolean
        Get
            Return enabledValue
        End Get
        Set(ByVal value As Boolean)
            enabledValue = value
        End Set
    End Property

    Public Overrides Function Clone() As Object
        Dim cell As DataGridViewDisableButtonCell = CType(MyBase.Clone(), DataGridViewDisableButtonCell)
        cell.Enabled = Me.Enabled
        Return cell
    End Function

    Public Sub New()
        Me.enabledValue = True
    End Sub

    Protected Overrides Sub Paint(ByVal graphics As Graphics, ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle, ByVal rowIndex As Integer, ByVal elementState As DataGridViewElementStates, ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, ByVal paintParts As DataGridViewPaintParts)
        If Not Me.enabledValue Then

            If (paintParts And DataGridViewPaintParts.Background) = DataGridViewPaintParts.Background Then
                Dim cellBackground As SolidBrush = New SolidBrush(cellStyle.BackColor)
                graphics.FillRectangle(cellBackground, cellBounds)
                cellBackground.Dispose()
            End If

            If (paintParts And DataGridViewPaintParts.Border) = DataGridViewPaintParts.Border Then
                PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle)
            End If

            Dim buttonArea As Rectangle = cellBounds
            Dim buttonAdjustment As Rectangle = Me.BorderWidths(advancedBorderStyle)
            buttonArea.X += buttonAdjustment.X
            buttonArea.Y += buttonAdjustment.Y
            buttonArea.Height -= buttonAdjustment.Height
            buttonArea.Width -= buttonAdjustment.Width
            ButtonRenderer.DrawButton(graphics, buttonArea, PushButtonState.Disabled)

            If TypeOf Me.FormattedValue Is String Then
                TextRenderer.DrawText(graphics, CStr(Me.FormattedValue), Me.DataGridView.Font, buttonArea, SystemColors.GrayText)
            End If
        Else
            MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)
        End If
    End Sub
End Class
