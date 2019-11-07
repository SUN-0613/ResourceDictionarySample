using AYam.Common.MVVM;
using ResourceDictionarySample.Kind;
using System;
using System.IO;
using System.Windows;
using System.Windows.Markup;

namespace ResourceDictionarySample.Forms.ViewModel
{

    /// <summary>ResourceDictionary.ViewModel</summary>
    public class Sample : ViewModelBase
    {

        #region Model

        private Model.Sample _Model = new Model.Sample();

        #endregion

        #region Property

        public string LanguageProperty { get { return _Model.GetLanguageSource(SelectedLanguage); } }

        public Languages SelectedLanguage
        {
            get { return _SelectedLanguage; }
            set
            {
                _SelectedLanguage = value;
                CallPropertyChanged(nameof(LanguageProperty));
                CallPropertyChanged(nameof(TextProperty));
            }
        }

        public string TextProperty
        {
            get
            {

                if (Dictionary != null)
                {
                    return Dictionary["CodeBehind"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
        }

        public ResourceDictionary Dictionary { get; set; }

        public string InputText { get; set; }

        public DelegateCommand UpdateCommand { get; set; }

        #endregion

        private Languages _SelectedLanguage = Languages.Default;

        public Sample()
        {

            var uri = new Uri(_Model.GetLanguageSource(SelectedLanguage), UriKind.Relative);
            Dictionary = new ResourceDictionary() { Source = uri };

            UpdateCommand = new DelegateCommand(
                ()=> 
                {

                    Dictionary["CodeBehind"] = InputText;
                    CallPropertyChanged(nameof(TextProperty));

                    using (var writer = new StreamWriter(Dictionary.Source.ToString()))
                    {
                        XamlWriter.Save(Dictionary, writer);
                    }

                }
                ,() => true);

        }

    }

}
