using UnityEngine;

public class StickerButtonController : MonoBehaviour
{
    [SerializeField] private string stickerPackageURL = "https://sticker.ly/s/WJP6KB";

    public void OnClickSticker()
    {
        AdManager.instance.ShowAd(() =>
        {
            Application.OpenURL(stickerPackageURL);
        });
    }
}
