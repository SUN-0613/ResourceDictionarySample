using System;
using System.Windows;
using System.Windows.Interactivity;

namespace ResourceDictionarySample.Behaviors
{
    public class ResourceDictionaryTriggerAction : TriggerAction<FrameworkElement>
    {

        #region DependencyProperty

        public static readonly DependencyProperty DictionaryProperty
            = DependencyProperty.Register(
                nameof(Dictionary),
                typeof(ResourceDictionary),
                typeof(ResourceDictionaryTriggerAction),
                new PropertyMetadata(null));

        #endregion

        #region Property

        public ResourceDictionary Dictionary
        {
            get { return (ResourceDictionary)GetValue(DictionaryProperty); }
            set { SetValue(DictionaryProperty, value); }
        }

        #endregion

        protected override void Invoke(object parameter)
        {
         
            if (parameter is DependencyPropertyChangedEventArgs e)
            {

                //if (e.OldValue is string oldLanguage)
                //{

                //    var oldUri = new Uri(oldLanguage, UriKind.Relative);

                //    for (var iLoop = 0; iLoop < AssociatedObject.Resources.MergedDictionaries.Count; iLoop++)
                //    {

                //        if (AssociatedObject.Resources.MergedDictionaries[iLoop].Source.Equals(oldUri))
                //        {
                //            AssociatedObject.Resources.MergedDictionaries.RemoveAt(iLoop);
                //            break;
                //        }

                //    }

                //}

                if (e.NewValue is string newLanguage)
                {

                    var newUri = new Uri(newLanguage, UriKind.Relative);
                    Dictionary = new ResourceDictionary() { Source = newUri };

                    //AssociatedObject.Resources.MergedDictionaries.Add(Dictionary);
                    AssociatedObject.Resources.MergedDictionaries[0] = Dictionary;

                }

            }

        }

    }

}
