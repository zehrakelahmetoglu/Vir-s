⌨️ **A-Key Only: Klavye Manipülasyon Projesi**
Bu proje, C# ve Win32 API kullanarak geliştirilmiş, eğitim amaçlı bir "Zararlı Yazılım ve Panzehir" simülasyonudur. Sistem kancaları (Hooking) ve süreç yönetimi (Process Management) mantığını anlamak için tasarlanmıştır.

---

🚀 **PROJE BİLEŞENLERİ**

**1. Virüs**

Düşük seviyeli bir klavye kancası (WH_KEYBOARD_LL) atarak kullanıcı girişlerini dinler.

Özellik: 'A' tuşu dışındaki tüm tuş vuruşlarını işletim sistemine ulaşmadan engeller.

Teknik: user32.dll üzerinden SetWindowsHookEx fonksiyonunu kullanır.


**2. Antivirüs**

Sistemde çalışan süreçleri tarayan ve imza tabanlı (isim kontrolü) temizlik yapan bir araçtır.

Özellik: Virüs sürecini tespit eder ve anında sonlandırarak klavye kontrolünü kullanıcıya geri verir.

Teknik: System.Diagnostics kütüphanesini kullanır.

---

🛠️**KURULUM VE ÇALIŞTIRMA**

Visual Studio'yu "Yönetici Olarak" çalıştırın.

SakaVirusu projesini derleyin (Build) ve çalıştırın.

Klavyenin kilitlendiğini ve sadece 'A' yazdığını test edin.

SakaSavunma uygulamasını açın ve "Sistemi Temizle" butonuna basarak sistemi kurtarın.

---

⚠️ **ÖNEMLİ UYARILAR**

Bu proje sadece eğitim ve test amaçlıdır.

Bir başkasının bilgisayarında izinsiz kullanılması etik dışıdır ve yasal sorumluluk doğurabilir.

Test sırasında Ctrl + Alt + Del kombinasyonu Windows tarafından korunduğu için her zaman çalışmaya devam eder (Acil çıkış kapısı).

---

💻 **KULLANILAN TEKNOLOJİLER**

Dil: C#

Platform: .NET Framework

API: Win32 (user32.dll, kernel32.dll)

