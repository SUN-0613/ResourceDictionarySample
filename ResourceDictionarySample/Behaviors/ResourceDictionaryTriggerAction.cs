using System;
using System.Windows;
using System.Windows.Interactivity;

namespace ResourceDictionarySample.Behaviors
{
    public class ResourceDictionaryTriggerAction : TriggerAction<FrameworkElement>
    {


        protected override void Invoke(object parameter)
        {
         
            if (parameter is DependencyPropertyChangedEventArgs e)
            {

                if (e.OldValue is string oldLanguage)
                {

                    var oldUri = new Uri(oldLanguage, UriKind.Relative);

                    for (var iLoop = 0; iLoop < AssociatedObject.Resources.MergedDictionaries.Count; iLoop++)
                    {

                        if (AssociatedObject.Resources.MergedDictionaries[iLoop].Source.Equals(oldUri))
                        {
                            AssociatedObject.Resources.MergedDictionaries.RemoveAt(iLoop);
                            break;
                        }

                    }

                }

                if (e.NewValue is string newLanguage)
                {

                    var uri = new Uri(newLanguage, UriKind.Relative);
                    var dic = new ResourceDictionary() { Source = uri };

                    AssociatedObject.Resources.MergedDictionaries.Add(dic);

                }

            }

        }

    }

}
