
# Çoklu Dil Çevirisi Otomasyonu

C# Windows Forms ile geliştirilmiş, Microsoft Translator API kullanan çoklu dil çevirisi otomasyon uygulaması.

## 🚀 Özellikler

- ✅ Tek metni birden fazla dile çevirme
- ✅ Otomatik dil algılama
- ✅ Modern Windows Forms arayüzü
- ✅ API anahtarı yönetimi (Ayarlar menüsünden)
- ✅ 30+ dil desteği
- ✅ Çeviri sonuçlarını kopyalama

## 📋 Gereksinimler

- .NET 8.0 SDK veya üzeri
- Microsoft Translator API anahtarı (Azure Portal'dan alınabilir)

## 🔧 Kurulum

1. **Projeyi klonlayın veya indirin**

2. **NuGet paketlerini yükleyin:**
   ```bash
   dotnet restore
   ```

3. **API anahtarını yapılandırın:**
   - Uygulamayı çalıştırın
   - "⚙️ Ayarlar" butonuna tıklayın
   - API anahtarınızı girin ve kaydedin
   - Alternatif olarak `appsettings.json` dosyasını manuel olarak düzenleyebilirsiniz

## 🔑 API Anahtarı Nasıl Alınır?

1. [Azure Portal](https://portal.azure.com)'a gidin
2. "Create a resource" → "Translator" arayın
3. Translator kaynağını oluşturun
4. Oluşturulan kaynağa gidin
5. "Keys and Endpoint" bölümünden API anahtarınızı kopyalayın
6. `appsettings.json` dosyasına yapıştırın

## 💰 Fiyatlandırma

**Azure Translator API:**
- ✅ **Ücretsiz Tier**: Aylık 2 milyon karakter (kalıcı olarak ücretsiz)
- 💵 **Ücretli Tier**: Limit aşıldığında ~$10 / 1 milyon karakter

**Notlar:**
- Küçük/orta ölçekli kullanımlar için ücretsiz limit genellikle yeterlidir
- Yeni Azure hesaplarında ilk 30 gün için $200 kredi verilir
- Azure Portal'dan kullanım miktarınızı takip edebilirsiniz

**Ücretsiz kullanım için öneriler:**
- Günlük maksimum ~66.000 karakter çeviri yapabilirsiniz (aylık 2M / 30 gün)
- Kullanım limitlerini kontrol etmek için Azure Portal → Cost Management kullanın

## 💻 Kullanım

### Projeyi Çalıştırma

```bash
dotnet run
```

veya Visual Studio'da F5 ile çalıştırın.

### Arayüz Kullanımı

1. **Kaynak Metin**: Çevirmek istediğiniz metni girin
2. **Kaynak Dil**: Kaynak dili seçin veya "🔍 Otomatik Algıla" butonuna tıklayın
3. **Hedef Diller**: Çeviri yapmak istediğiniz dilleri seçin (birden fazla seçebilirsiniz)
   - "Tümünü Seç" ile tüm dilleri seçebilirsiniz
   - "Tümünü Kaldır" ile seçimleri temizleyebilirsiniz
4. **Çevir**: "🚀 Çevir" butonuna tıklayın
5. **Sonuçlar**: Çeviri sonuçları sağ panelde görüntülenecektir

### Özellikler

- **Otomatik Dil Algılama**: "🔍 Otomatik Algıla" butonu metnin dilini otomatik algılar
- **Ayarlar**: "⚙️ Ayarlar" butonu ile API anahtarını yönetebilirsiniz
- **Temizle**: "Temizle" butonu ile tüm metinleri temizleyebilirsiniz

## 🌍 Desteklenen Dil Kodları

- `tr` - Türkçe
- `en` - İngilizce
- `de` - Almanca
- `fr` - Fransızca
- `es` - İspanyolca
- `it` - İtalyanca
- `ru` - Rusça
- `ar` - Arapça
- `ja` - Japonca
- `zh` - Çince

[Daha fazla dil kodu için Microsoft Translator dokümantasyonunu inceleyin](https://docs.microsoft.com/azure/cognitive-services/translator/language-support)

## 📁 Proje Yapısı

```
TranslationAutomation/
├── Forms/
│   ├── MainForm.cs               # Ana form
│   ├── MainForm.Designer.cs      # Ana form tasarımı
│   ├── SettingsForm.cs           # Ayarlar formu
│   └── SettingsForm.Designer.cs  # Ayarlar formu tasarımı
├── Models/
│   └── TranslationRequest.cs      # Veri modelleri
├── Services/
│   └── TranslationService.cs      # Çeviri servisi
├── Configuration/
│   └── AppConfig.cs               # Konfigürasyon yönetimi
├── Program.cs                     # Ana program (Windows Forms)
├── appsettings.json              # API ayarları
└── TranslationAutomation.csproj  # Proje dosyası
```

## ⚙️ Konfigürasyon

`appsettings.json` dosyasında aşağıdaki ayarları düzenleyebilirsiniz:

```json
{
  "TranslationApi": {
    "ApiKey": "YOUR_API_KEY",
    "ApiUrl": "https://api.cognitive.microsofttranslator.com/translate",
    "Region": "global",
    "ApiVersion": "3.0"
  }
}
```

## 📝 Notlar

- API anahtarı güvenli bir şekilde saklanmalıdır
- `appsettings.json` dosyasını git'e eklememek için `.gitignore` kullanın
- API kullanım limitlerine dikkat edin
- İnternet bağlantısı gereklidir

## 🐛 Sorun Giderme

**API anahtarı hatası alıyorsanız:**
- `appsettings.json` dosyasında API anahtarının doğru girildiğinden emin olun
- Azure Portal'dan API anahtarının aktif olduğunu kontrol edin

**Çeviri hatası alıyorsanız:**
- İnternet bağlantınızı kontrol edin
- Dil kodlarının doğru olduğundan emin olun
- API kullanım limitinizi kontrol edin

## 📄 Lisans

Bu proje eğitim amaçlıdır.

