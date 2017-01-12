using GalaSoft.MvvmLight;

namespace Gevlee.RsaChat.Client.App.ModelWrappers
{
	public abstract class BaseModelWrapper<TModel> : ObservableObject
	{
		public TModel Model { get; set; }
		protected BaseModelWrapper(TModel model)
		{
			Model = model;
		}

		public abstract void Replace(TModel model);
	}
}