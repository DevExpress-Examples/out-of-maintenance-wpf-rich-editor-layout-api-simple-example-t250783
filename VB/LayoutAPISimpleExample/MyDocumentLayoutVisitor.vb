Namespace LayoutAPISimpleExample
    #Region "#MyDocumentLayoutVisitor"
Friend Class MyDocumentLayoutVisitor
    Inherits DevExpress.XtraRichEdit.API.Layout.LayoutVisitor

    Protected Overrides Sub VisitRow(ByVal row As DevExpress.XtraRichEdit.API.Layout.LayoutRow)
        If row.GetParentByType(Of DevExpress.XtraRichEdit.API.Layout.LayoutPageArea)() IsNot Nothing Then
            System.Diagnostics.Debug.WriteLine("This row is located at X: {0}, Y: {1}, related range starts at {2}", row.Bounds.X, row.Bounds.Y, row.Range.Start)
        End If
        ' Call the base VisitRow method to walk down the tree to the child elements of the Row.
        ' If you don't need them, comment out the next line. 
        MyBase.VisitRow(row)
    End Sub

    Protected Overrides Sub VisitPage(ByVal page As DevExpress.XtraRichEdit.API.Layout.LayoutPage)
        System.Diagnostics.Debug.WriteLine("Visiting page {0}", page.Index +1)
        MyBase.VisitPage(page)
    End Sub
End Class
    #End Region ' #MyDocumentLayoutVisitor
End Namespace
