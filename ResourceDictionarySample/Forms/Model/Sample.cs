using ResourceDictionarySample.Kind;

namespace ResourceDictionarySample.Forms.Model
{

    /// <summary>ResourceDictionary.Model</summary>
    public class Sample
    {

        public string GetLanguageSource(Languages language)
        {

            // .exeからみたファイルパスを設定
            switch (language)
            {

                case Languages.Japanese:
                    return @"Forms/Languages/ja-JP/Sample.xaml";

                case Languages.English:
                    return @"Forms/Languages/en-US/Sample.xaml";

                default:
                    return @"Forms/Languages/Default/Sample.xaml";

            }

        }

    }

}
