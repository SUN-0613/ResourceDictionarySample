using AYam.Common.MVVM;

namespace ResourceDictionarySample.Forms.ViewModel
{

    /// <summary>ResourceDictionary.ViewModel</summary>
    public class Sample : ViewModelBase
    {

        #region Property

        public string LanguageProperty { get; set; } = @"../Forms/Languages/Default/Sample.xaml";

        public DelegateCommand ChangeCommand { get; private set; }

        #endregion

        public Sample()
        {

            ChangeCommand = new DelegateCommand(() => 
            {
                LanguageProperty = @"../Forms/Languages/en-US/Sample.xaml";
                CallPropertyChanged(nameof(LanguageProperty));
            });

        }

    }

}
