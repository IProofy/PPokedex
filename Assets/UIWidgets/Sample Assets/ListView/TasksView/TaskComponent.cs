using UnityEngine.UI;
using UIWidgets;

namespace UIWidgetsSamples.Tasks {
	public class TaskComponent : ListViewItem {
		public Text Name;

		public Progressbar Progressbar;

		Task item;

		public Task Item {
			get {
				return item;
			}
			set {
				if (item!=null)
				{
					item.OnProgressChange -= UpdateProgressbar;
				}
				item = value;
				if (item!=null)
				{
					Name.text = item.Name;
					Progressbar.Value = item.Progress;

					item.OnProgressChange += UpdateProgressbar;
				}
			}
		}

		public void SetData(Task item)
		{
			Item = item;
		}

		void UpdateProgressbar()
		{
			Progressbar.Animate(item.Progress);
		}

		protected override void OnDestroy()
		{
			Item = null;
		}
	}
}