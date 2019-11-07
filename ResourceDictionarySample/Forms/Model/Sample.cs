using ResourceDictionarySample.Kind;

namespace ResourceDictionarySample.Forms.Model
{

    /// <summary>ResourceDictionary.Model</summary>
    public class Sample
    {

        public string GetLanguageSource(Languages language)
        {

            // Behaviorクラスからみたファイルパスを設定
            switch (language)
            {

                case Languages.Japanese:
                    return @"/ResourceDictionarySample;component/Forms/Languages/ja-JP/Sample.xaml";

                case Languages.English:
                    return @"/ResourceDictionarySample;component/Forms/Languages/en-US/Sample.xaml";

                default:
                    return @"/ResourceDictionarySample;component/Forms/Languages/Default/Sample.xaml";

            }

        }

    }

}
