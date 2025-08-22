# E-Payroll

E-Payroll is a sample payroll application containing a .NET API and an Angular UI. The repository includes a Docker Compose stack to run the API, UI, and a SQL Server database locally.

## Contents
- `API/E-Payroll.API.Web` - .NET 9 Web API
- `UI/E-Payroll.UI` - Angular application (built with Angular CLI)
- `Infrastructure` / `Core` / `Application` - supporting projects
- `docker-compose.yml` - brings up the UI, API and DB for local development

## Prerequisites
- Docker Desktop (with WSL2 on Windows)
- (Optional for local dev) .NET SDK 9.x
- (Optional for local UI dev) Node 20 and npm, Angular CLI

## Quick start (recommended)
1. From the repository root, build and start services with Docker Compose:

```powershell
cd F:\Prog-Projects\E-Payroll
docker compose up -d --build
```

2. UI: Open http://localhost:8080
3. API: Accessible at http://localhost:5000 (HTTP) and https://localhost:5001 (HTTPS)
4. Database: SQL Server listens on host port 1433 (see `docker-compose.yml`).

## Local development (without Docker)
- API
  - Build: `dotnet build API/E-Payroll.API.Web/E-Payroll.API.Web.csproj`
  - Run: `dotnet run --project API/E-Payroll.API.Web/E-Payroll.API.Web.csproj`
- UI
  - Install: `cd UI/E-Payroll.UI; npm install`
  - Serve (dev): `ng serve --host 0.0.0.0`
  - Build (prod): `ng build --configuration production`

## Notes & Troubleshooting
- If you see the nginx welcome page instead of the Angular app on http://localhost:8080:
  - Hard-refresh the browser (Ctrl+F5) or use an incognito window to avoid cache issues.
  - Confirm the UI container contains the Angular files under `/usr/share/nginx/html` (index.html, main-*.js, polyfills-*.js).
  - Rebuild the UI image and restart the UI service: `docker compose build --no-cache e-payroll.ui && docker compose up -d e-payroll.ui`.

- Known code issue encountered during local debugging: some generated C# namespaces contained hyphens (e.g. `E-Payroll.Core.Domain`), which are invalid identifiers in C#. If you get many compiler errors (CS0116 / CS1513 / CS1514), search for `E-Payroll` in the C# files and replace the hyphen with an underscore (for example `E_Payroll.Core.Domain`) or restore the corrected files from the commit history.

## Contributing
- Create a feature branch off `main`.
- Open a pull request with a descriptive title and tests where appropriate.

## License
Add your license here. (This README was generated automatically.)



# 🏥 نظام إدارة شئون العاملين - كلية الطب
## Faculty Staff Management System

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-5C2D91?style=flat&logo=.net&logoColor=white)](https://dotnet.microsoft.com/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/en-us/sql-server)
[![Status](https://img.shields.io/badge/Status-Under%20Development-orange.svg)](https://github.com/yourusername/faculty-staff-management)

نظام شامل لإدارة شئون الموظفين وأعضاء هيئة التدريس في كلية الطب، يوفر إدارة متكاملة للرواتب والحضور والإجازات والجزاءات التأديبية وفقاً للقوانين المصرية.

---

## 📋 المحتويات

- [نظرة عامة](#-نظرة-عامة)
- [الميزات الرئيسية](#-الميزات-الرئيسية)
- [التقنيات المستخدمة](#️-التقنيات-المستخدمة)
- [هيكل قاعدة البيانات](#-هيكل-قاعدة-البيانات)
- [متطلبات النظام](#-متطلبات-النظام)
- [التثبيت](#-التثبيت)
- [الاستخدام](#-الاستخدام)
- [لقطات الشاشة](#-لقطات-الشاشة)
- [المساهمة](#-المساهمة)
- [الترخيص](#-الترخيص)
- [الدعم](#-الدعم)

---

## 🎯 نظرة عامة

نظام إدارة شئون العاملين هو حل متكامل مصمم خصيصاً لإدارة الموارد البشرية في المؤسسات التعليمية والطبية. يدعم النظام إدارة فئتين رئيسيتين من الموظفين:

- **الموظفين الإداريين**: وفقاً لنظام الخدمة المدنية المصري
- **أعضاء هيئة التدريس**: وفقاً للقوانين الأكاديمية والجامعية

## ✨ الميزات الرئيسية

### 👥 إدارة الموظفين
- ✅ تسجيل وتحديث بيانات الموظفين الشاملة
- ✅ إدارة الهيكل التنظيمي (الكليات والأقسام)
- ✅ تتبع التاريخ الوظيفي والترقيات
- ✅ إدارة الوثائق والمستندات الرقمية

### 💰 نظام الرواتب المتطور
- ✅ حساب الرواتب بناءً على معادلات مرنة قابلة للتخصيص
- ✅ إدارة عناصر الأجر (راتب أساسي، بدلات، حوافز، خصومات)
- ✅ دعم المعادلات المعقدة والحسابات التلقائية
- ✅ إنتاج كشوف رواتب تفصيلية وقسائم أجور
- ✅ حساب الضرائب والتأمينات تلقائياً

### ⏰ نظام الحضور والانصراف
- ✅ تتبع الحضور اليومي والشهري
- ✅ حساب الساعات الإضافية والتأخيرات
- ✅ إدارة الغياب والإجازات
- ✅ تقارير مفصلة عن الحضور

### 📝 إدارة الطلبات والإجازات
- ✅ workflow متكامل لموافقة الطلبات
- ✅ أنواع مختلفة من الإجازات (سنوية، مرضية، عارضة)
- ✅ تتبع رصيد الإجازات
- ✅ إشعارات تلقائية للمسؤولين

### ⚖️ النظام التأديبي
- ✅ إدارة الجزاءات والعقوبات
- ✅ تتبع المخالفات والقرارات التأديبية
- ✅ ربط الجزاءات بخصومات الراتب

### 🏛️ المرجعيات القانونية
- ✅ قاعدة بيانات شاملة للقوانين واللوائح
- ✅ ربط الإجراءات بالمواد القانونية
- ✅ تحديث مستمر للتشريعات

### 🔐 الأمان والصلاحيات
- ✅ نظام مستخدمين متعدد المستويات
- ✅ صلاحيات مرنة قابلة للتخصيص
- ✅ سجل تدقيق شامل لجميع العمليات
- ✅ النسخ الاحتياطي التلقائي

---

## 🛠️ التقنيات المستخدمة

### Backend
- **Framework**: ASP.NET Core 6.0
- **Language**: C# 10.0
- **Database**: Microsoft SQL Server 2019+
- **ORM**: Entity Framework Core
- **Authentication**: JWT Token Authentication
- **API**: RESTful Web API

### Frontend
- **Framework**: Angular 15+ / React 18+
- **Styling**: Bootstrap 5 + CSS3
- **Charts**: Chart.js / D3.js
- **Icons**: Font Awesome

### Architecture
- **Pattern**: Clean Architecture
- **Design**: Domain-Driven Design (DDD)
- **Caching**: Redis
- **Logging**: Serilog
- **Testing**: xUnit, Moq

---

## 🗄️ هيكل قاعدة البيانات

النظام يتكون من **6 وحدات رئيسية** مترابطة:

### 1. الطبقة الأساسية (Core Layer)
```sql
- Persons              -- بيانات الأشخاص الأساسية
- Colleges             -- الكليات
- Departments          -- الأقسام والوحدات
- PersonContacts       -- بيانات الاتصال
- PersonDocuments      -- الوثائق والمستندات
```

### 2. نظام الخدمة المدنية (Civil Service)
```sql
- CivilServiceGrades   -- الدرجات الوظيفية
- CivilServiceJobs     -- الوظائف
- PersonCivilAssignments -- إسناد الموظفين للوظائف
```

### 3. نظام هيئة التدريس (Faculty System)
```sql
- FacultyGrades        -- الدرجات الأكاديمية
- FacultyPositions     -- المناصب الأكاديمية
- PersonFacultyAssignments -- إسناد أعضاء هيئة التدريس
```

### 4. نظام الرواتب (Payroll System)
```sql
- PayElements          -- عناصر الأجر والخصم
- PersonPayAssignments -- إسناد العناصر للأشخاص
- PayrollRuns          -- دورات تشغيل الرواتب
- PayrollLines         -- سطور كشوف الرواتب
- PayrollLineDetails   -- تفاصيل كل عنصر أجر
```

### 5. الحضور والإجازات (Attendance & Leave)
```sql
- Attendance           -- سجل الحضور اليومي
- LeaveTypes           -- أنواع الإجازات
- LeaveRequests        -- طلبات الإجازات
- LeaveBalances        -- أرصدة الإجازات
```

### 6. الأمان والمرجعيات (Security & References)
```sql
- Users                -- مستخدمي النظام
- Roles                -- الأدوار والصلاحيات
- LegalReferences      -- المرجعيات القانونية
- AuditLog             -- سجل التدقيق
```

---

## 📋 متطلبات النظام

### الخادم (Server Requirements)
- **نظام التشغيل**: Windows Server 2016+ / Linux (Ubuntu 18.04+)
- **المعالج**: Intel Core i5 أو أفضل
- **الذاكرة**: 8 GB RAM (16 GB مستحسن)
- **التخزين**: 100 GB مساحة فارغة
- **قاعدة البيانات**: SQL Server 2019+ / PostgreSQL 12+

### العميل (Client Requirements)
- **المتصفح**: Chrome 90+, Firefox 88+, Safari 14+, Edge 90+
- **الشاشة**: دقة 1366x768 كحد أدنى
- **الإنترنت**: اتصال مستقر بسرعة 10 Mbps

---

## 🚀 التثبيت

### 1. استنساخ المشروع
```bash
git clone https://github.com/yourusername/faculty-staff-management.git
cd faculty-staff-management
```

### 2. إعداد قاعدة البيانات
```bash
# إنشاء قاعدة البيانات
sqlcmd -S localhost -Q "CREATE DATABASE FacultyStaffManagement"

# تشغيل الـ Migrations
dotnet ef database update
```

### 3. إعداد ملف التكوين
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=FacultyStaffManagement;Trusted_Connection=true;"
  },
  "JwtSettings": {
    "SecretKey": "your-secret-key-here",
    "Issuer": "FacultyStaffManagement",
    "ExpiryInHours": 24
  }
}
```

### 4. تشغيل التطبيق
```bash
# Backend
cd src/FacultyStaffManagement.API
dotnet run

# Frontend (في terminal منفصل)
cd src/FacultyStaffManagement.Web
npm install
ng serve
```

### 5. الوصول للنظام
- **التطبيق**: http://localhost:4200
- **API Documentation**: http://localhost:5000/swagger
- **بيانات الدخول الافتراضية**:
  - المستخدم: `admin@faculty.edu.eg`
  - كلمة المرور: `Admin@123`

---

## 📖 الاستخدام

### إدارة الموظفين
```bash
1. الدخول إلى النظام بحساب المدير
2. التوجه إلى قسم "الموظفين"
3. إضافة موظف جديد أو تعديل البيانات الموجودة
4. تحديد نوع الموظف (إداري / عضو هيئة تدريس)
```

### تشغيل الرواتب
```bash
1. الانتقال إلى قسم "الرواتب"
2. اختيار فترة الراتب (شهر/سنة)
3. تحديد نوع التشغيل (أساسي/حوافز/تسوية)
4. مراجعة البيانات والموافقة
5. طباعة كشوف الرواتب وقسائم الأجور
```

### إدارة الحضور
```bash
1. تسجيل الحضور اليومي (يدوي أو تلقائي)
2. مراجعة تقارير الحضور الشهرية
3. تسجيل الإجازات والغياب
4. حساب الساعات الإضافية
```

---

## 🤝 المساهمة

نرحب بمساهماتكم في تطوير هذا المشروع! للمساهمة:

### 1. Fork المشروع
```bash
git fork https://github.com/yourusername/faculty-staff-management.git
```

### 2. إنشاء branch جديد
```bash
git checkout -b feature/new-feature
```

### 3. Commit التغييرات
```bash
git commit -m "Add new feature: description"
```

### 4. Push للـ branch
```bash
git push origin feature/new-feature
```

### 5. إنشاء Pull Request
قم بإنشاء Pull Request من خلال GitHub interface

### معايير المساهمة
- اتبع الـ coding standards المعمول بها
- أضف unit tests للميزات الجديدة
- تأكد من عدم كسر الـ existing functionality
- أضف documentation للتغييرات

---

## 📄 الترخيص

هذا المشروع مرخص تحت [رخصة MIT](LICENSE) - راجع ملف LICENSE للتفاصيل.

---

## 💬 الدعم

### التواصل والدعم
- **GitHub Issues**: [إنشاء issue جديد](https://github.com/yourusername/faculty-staff-management/issues)
- **البريد الإلكتروني**: support@facultystaff.com
- **التوثيق**: [Wiki](https://github.com/yourusername/faculty-staff-management/wiki)

---

## 🙏 شكر وتقدير

نشكر جميع المساهمين في هذا المشروع:

<a href="https://github.com/yourusername/faculty-staff-management/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=yourusername/faculty-staff-management" />
</a>

---

<div align="center">
  <h3>⭐ إذا أعجبك المشروع، لا تنس إعطاءه نجمة! ⭐</h3>
  <p>صنع بـ ❤️ من أجل المؤسسات التعليمية المصرية</p>
</div>

