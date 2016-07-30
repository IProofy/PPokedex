using UIWidgets;

namespace UIWidgetsSamples.Tasks {
	public class TaskView : ListViewCustom<TaskComponent,Task> {
		public static readonly System.Comparison<Task> ItemsComparison = (x, y) => x.Name.CompareTo(y.Name);

		bool isStartedTaskView = false;

		public override void Start()
		{
			if (isStartedTaskView)
			{
				return ;
			}
			isStartedTaskView = true;

			base.Start();
			DataSource.Comparison = ItemsComparison;
		}

		protected override void SetData(TaskComponent component, Task item)
		{
			component.SetData(item);
		}

		protected override void HighlightColoring(TaskComponent component)
		{
			base.HighlightColoring(component);
			component.Name.color = HighlightedColor;
		}

		protected override void SelectColoring(TaskComponent component)
		{
			base.SelectColoring(component);
			component.Name.color = SelectedColor;
		}

		protected override void DefaultColoring(TaskComponent component)
		{
			base.DefaultColoring(component);
			component.Name.color = DefaultColor;
		}
	}
}