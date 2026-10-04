using UnityEngine; //unity temel kütüphane

public class Top : MonoBehaviour //top adında unity objeleri eklenebilen bir sınıf
{
    [Header("otopark ayarları")] //inspector panelinde bulunan değişikenlerin başlığı
    [Tooltip("aracın otoparkta kaldığı süre (Saat)")] //inspectorde değişkenin üzerine gelindiğinde ipucu göstericek
    [SerializeField] private int kalinanSaat = 0; //değişkeni gizli tutar ama inspectırda değiştirilmesine izin verir

    private void Start() //unity tarafından oto olarak bir kez çağırılır
    {
        OtaparkUcretiHesaplama(); //ücret hesaplayan fonksiyonu çağırdık  
    }

    private void OnValidate() //inspector panelinde değeer değiştirildiği an oto çalışır
    {
        if (kalinanSaat < 0) //kullanıcının negatif sayı girmesini engeller
            kalinanSaat = 0; //saat 0 ise 0 olucak eksi değer döndürmicek

        OtaparkUcretiHesaplama(); //bu da inspectorda değer değiştiği gibi hesaplayıp tekrar konsola yazıcak
    }

    private void OtaparkUcretiHesaplama()
    {
        int ucret = 0; //ücreti tutacak olan tam sayı değişkeni oluşturuldu başlanfıç 0
        switch (kalinanSaat) //kalınansaat değişkeninin değerine göre farklı durumları kontrol eden klasik switch yapısı
        {
            case 0: //eğer kalınan saat == 0 ise 
                ucret = 0; //ücreti 0 tl yapar
                break; // switch`in işi  biter alttakileri kontrol etmeden biter satır çalışırsa
             
            case 1:
                ucret = 150;
                break;
             
            case 2:
                ucret = 200;
                break;                                                  
              
            case 3:
                ucret = 270;
                break;

            default: // hiçbiri çalışmaz ise default çalışır
                ucret = (kalinanSaat * 110) + 50;
                break;
        }
        
        //Debug.Log("otoparkta kalınan süre: " + kalinanSaat + "saat. ücret: " + ucret + "₺");
        Debug.Log($"otoparkta kalınan süre: {kalinanSaat}. toplam ücret : {ucret}₺"); //çıktıda değişkenlerin bir arada kullanmanın modern yolu

      /* Debug.Log("normal mesaj");
       * Debug.LogWarning("sarı dikkat mesaj");
       * Debug.LogEror("kırmızı hata")
       */ 
       

    }


}
