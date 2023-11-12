using Xamarin.Forms;

namespace UNANMovilV2.Funciones
{
    public class DisplayMemberPicker : Picker
    {
        public static readonly BindableProperty DisplayMemberPathProperty =
            BindableProperty.Create(nameof(DisplayMemberPath), typeof(string), typeof(DisplayMemberPicker), "");

        public string DisplayMemberPath
        {
            get => (string)GetValue(DisplayMemberPathProperty);
            set => SetValue(DisplayMemberPathProperty, value);
        }
    }
}
