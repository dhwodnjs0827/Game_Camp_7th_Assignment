public class PopupUI : BaseUI
{
    protected bool isCloseOnBackgroundClick = true;

    public override void Show()
    {
        base.Show();
        transform.SetAsLastSibling();
    }
}
