﻿Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpf.Docking
Imports Microsoft.Practices.Prism.Regions

Namespace PrismSupportSample
	Public Class LayoutPanelAdapter
		Inherits RegionAdapterBase(Of LayoutPanel)
		Public Sub New(ByVal behaviorFactory As IRegionBehaviorFactory)
			MyBase.New(behaviorFactory)
		End Sub
		Protected Overrides Function CreateRegion() As IRegion
			Return New SingleActiveRegion()
		End Function
		Protected Overrides Sub Adapt(ByVal region As IRegion, ByVal regionTarget As LayoutPanel)
			AddHandler region.Views.CollectionChanged, Sub(d, e)
				If e.NewItems IsNot Nothing Then
					regionTarget.Content = e.NewItems(0)
				End If
			End Sub
		End Sub
	End Class
End Namespace