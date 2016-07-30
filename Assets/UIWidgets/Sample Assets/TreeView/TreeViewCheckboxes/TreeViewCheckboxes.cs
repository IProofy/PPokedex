using UnityEngine;
using UIWidgets;

namespace UIWidgetsSamples {
	public class TreeViewCheckboxes : TreeViewCustom<TreeViewCheckboxesComponent,TreeViewCheckboxesItem> {
		public NodeEvent OnNodeCheckboxChanged = new NodeEvent();

		void NodeCheckboxChanged(int index)
		{
			OnNodeCheckboxChanged.Invoke(DataSource[index].Node);
		}

		protected override void AddCallback(ListViewItem item, int index)
		{
			base.AddCallback(item, index);

			(item as TreeViewCheckboxesComponent).NodeCheckboxChanged.AddListener(NodeCheckboxChanged);
		}

		protected override void RemoveCallback(ListViewItem item, int index)
		{
			if (item!=null)
			{
				(item as TreeViewCheckboxesComponent).NodeCheckboxChanged.RemoveListener(NodeCheckboxChanged);
				base.RemoveCallback(item, index);
			}
		}

		protected override void SetData(TreeViewCheckboxesComponent component, ListNode<TreeViewCheckboxesItem> item)
		{
			component.SetData(item.Node, item.Depth);
		}
		
		protected override void HighlightColoring(TreeViewCheckboxesComponent component)
		{
			if (component!=null)
			{
				base.HighlightColoring(component);
				component.Text.color = HighlightedColor;
			}
		}
		
		protected override void SelectColoring(TreeViewCheckboxesComponent component)
		{
			if (component!=null)
			{
				base.SelectColoring(component);
				component.Text.color = SelectedColor;
			}
		}
		
		protected override void DefaultColoring(TreeViewCheckboxesComponent component)
		{
			if (component!=null)
			{
				base.DefaultColoring(component);
				component.Text.color = DefaultColor;
			}
		}
	}
}