Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI.WebControls
Imports System.Web
Imports System.Net.Mail
Imports System.Net.Mime
Imports SolrNet.Commands.Parameters
Imports SolrNet.Attributes
Imports Microsoft.Practices.ServiceLocation
Imports SolrNet
Imports CommonServiceLocator

Public Class prj
    <SolrUniqueKey("prjid")> Public Property prjid() As String
        Get
            Return m_prjid
        End Get
        Set(value As String)
            m_prjid = value
        End Set
    End Property
    Private m_prjid As String


    <SolrField("tags")> Public Property tags() As String
        Get
            Return m_tags
        End Get
        Set(value As String)
            m_tags = value
        End Set
    End Property
    Private m_tags As String
    <SolrField("description")> Public Property description() As String
        Get
            Return m_description
        End Get
        Set(value As String)
            m_description = value
        End Set
    End Property
    Private m_description As String

    <SolrField("title")> Public Property title() As String
        Get
            Return m_Title
        End Get
        Set(value As String)
            m_Title = value
        End Set
    End Property
    Private m_Title As String

    <SolrField("cityname")> Public Property cityname() As String
        Get
            Return m_cityName
        End Get
        Set(value As String)
            m_cityName = value
        End Set
    End Property
    Private m_cityName As String
    <SolrField("group")> Public Property group() As String
        Get
            Return m_group
        End Get
        Set(value As String)
            m_group = value
        End Set
    End Property
    Private m_group As String

    Public server As String = "http://94.130.112.181:8983/solr/advm"
End Class
Public Class General

    Public Shared Function domain(ByVal name As String) As String
        Dim url As String = HttpContext.Current.Request.Url.Host.ToLower.Replace("www.", "")
        Dim result As String = ""
        Select Case url
            Case "localhost"
                Select Case name.ToLower
                    Case "domainname"
                        result = "localhost"
                    Case "fulldomainname"
                        result = "http://localhost:56556"
                    Case "folder"
                        result = "localhost"
                    Case "code"
                        result = "5"
                    Case "title"
                        result = "تست سامانه خبری در شبکه محلی | لوکال هاست | سامانه خبری سوین"
                    Case "keywords"
                        result = "پایگاه خبری تست,کلمه کلیدی فرضی , سایت خبری تستی"
                    Case "sitename"
                        result = "سامانه خبری سوین"
                    Case "sitefullname"
                        result = "پایگاه خبری سوین"
                    Case "desc"
                        result = " سامانه خبری جهت سئو سایتهای مجموعه سوین"
                    Case "firstindex"
                        result = "1"
                    Case "social-link1"
                        result = "#"
                    Case "social-link2"
                        result = "#"
                    Case "social-link3"
                        result = "#"
                    Case "social-class1"
                        result = "fa fa-youtube"
                    Case "social-class2"
                        result = "fa fa-instagram"
                    Case "social-class3"
                        result = "fa fa-telegram"

                    Case "signature"
                        result = ""

                    Case "googleanalyticsid"
                        result = "G-QH86DGVYXV"
                    Case "lang"
                        result = "en"
                    Case "dir"
                        result = "ltr"
                    Case "tel"
                        result = "+989123127516"

                End Select

            Case "sedayebiseda.ir"
                Select Case name.ToLower
                    Case "domainname"
                        result = "sedayebiseda.ir"
                    Case "fulldomainname"
                        result = "https://sedayebiseda.ir"

                    Case "folder"
                        result = "sedayebiseda"
                    Case "code"
                        result = "1"
                    Case "title"
                        result = "پایگاه خبری صدای بی صدا | آخرین خبر های ایران و جهان"
                    Case "keywords"
                        result = "پایگاه خبری صدای بی صدا,صدای بی صدا,اخبار دانشگاه,اخبار فناوری,اخبار گردشگری"
                    Case "sitename"
                        result = "صدای بی صدا"
                    Case "sitefullname"
                        result = "پایگاه خبری صدای بی صدا"
                    Case "desc"
                        result = "خبر های اقتصادی اجتماعی ورزشی سیاسی بین الملل گردشگری"
                    Case "firstindex"
                        result = "1"
                    Case "social-link1"
                        result = "#"
                    Case "social-link2"
                        result = "#"
                    Case "social-link3"
                        result = "#"
                    Case "social-class1"
                        result = "fa fa-youtube"
                    Case "social-class2"
                        result = "fa fa-instagram"
                    Case "social-class3"
                        result = "fa fa-telegram"
                    Case "signature"
                        result = ""
                    Case "googleanalyticsid"
                        result = "G-QH86DGVYXV"
                    Case "lang"
                        result = "fa"
                    Case "dir"
                        result = "rtl"
                    Case "tel"
                        result = "+989123127516"


                End Select

            Case "tabriztasfiye.com"
                Select Case name.ToLower
                    Case "domainname"
                        result = "tabriztasfiye.com"
                    Case "fulldomainname"
                        result = "https://tabriztasfiye.com"

                    Case "folder"
                        result = "tabriztasfiye"

                    Case "code"
                        result = "30011"
                    Case "title"
                        result = "تعمیر و فروش تصفیه آب در تبریز"
                    Case "keywords"
                        result = "تعویض فیلتر تصفیه آب در محل ,فروش تصفیه آب درتبریز, خدمات پکیج در تبریز"

                    Case "sitename"
                        result = "تبریز تصفیه"
                    Case "sitefullname"
                        result = "مجله تبریز تصفیه"
                    Case "desc"
                        result = "فروش دستگاه تصفیه آب و فیلتر و قطعات در تبریز"
                    Case "firstindex"
                        result = "1"
                    Case "social-link1"
                        result = "#"
                    Case "social-link2"
                        result = "https://www.instagram.com/tabrizTasfiye/"
                    Case "social-link3"
                        result = "#"
                    Case "social-class1"
                        result = "fa fa-youtube"
                    Case "social-class2"
                        result = "fa fa-instagram"
                    Case "social-class3"
                        result = "fa fa-telegram"
                    Case "signature"
                        result = "<br/><b>" + "پشتیبانی شرکت تبریز تصفیه" + "</b>" +
                            "<p>" + "دماپویش مرکز خدمات و نمایندگی نصب و تعمیرات برندهای مختلف تصفیه آب، همواره در خدمت شما همشهریان عزیز تبریزی می باشد." + "</p><br/>" +
                            "<p>" + "اگر تجهیزات کافی یا تخصص لازم را ندارید میتوانید با دماپویش تماس گرفته و سوالات خود را مطرح نمائید." + "</p><br/>" +
                            "<p>" + "آدرس: تبریز،شهرک نصر، میدان تجاری آذرآبادگان، پلاک 1075 " + "</p><br/>" +
                             "<center><a href=""https://tabriztasfiye.com""  target=""_blank"" >" + "فروش و تعمیرات دستگاه تصفیه آب در تبریز" + "</a>  : <strong> 09144606572 - 04136628871</strong></center>"
                    Case "googleanalyticsid"
                        result = "G-ZTXD6KFVJN"

                    Case "lang"
                        result = "fa"
                    Case "dir"
                        result = "rtl"
                    Case "tel"
                        result = "+989144606572"
                End Select


            Case "damapouyesh.com"
                Select Case name.ToLower
                    Case "domainname"
                        result = "damapouyesh.com"
                    Case "fulldomainname"
                        result = "https://damapouyesh.com"

                    Case "folder"
                        result = "damapouyesh"

                    Case "code"
                        result = "20005"
                    Case "title"
                        result = "دماپویش | خدمات کولرگازی پکیج و رادیاتور در تبریز"
                    Case "keywords"
                        result = "خدمات پکیج و ایران رادیاتور ,انجام خدمات در محل , خدمات پکیج در تبریز"

                    Case "sitename"
                        result = "دماپویش"
                    Case "sitefullname"
                        result = "پایگاه اطلاع رسانی دما پویش"
                    Case "desc"
                        result = "انجام خدمات سرمایش  و گرمایش در تبریز"
                    Case "firstindex"
                        result = "1"
                    Case "social-link1"
                        result = "#"
                    Case "social-link2"
                        result = "https://www.instagram.com/damapouyesh/"
                    Case "social-link3"
                        result = "#"
                    Case "social-class1"
                        result = "fa fa-youtube"
                    Case "social-class2"
                        result = "fa fa-instagram"
                    Case "social-class3"
                        result = "fa fa-telegram"

                    Case "signature"
                        result = "<br/><b>" + "پشتیبانی شرکت دماپویش" + "</b>" +
                            "<p>" + "دماپویش مرکز خدمات و نمایندگی نصب و تعمیرات برندهای مختلف پکیج، کولرگازی و بردهای الکترونیک، همواره در خدمت شما همشهریان عزیز تبریزی می باشد." + "</p><br/>" +
                            "<p>" + "اگر تجهیزات کافی یا تخصص لازم را ندارید میتوانید با دماپویش تماس گرفته و سوالات خود را مطرح نمائید." + "</p><br/>" +
                            "<p>" + "آدرس: تبریز،شهرک نصر، میدان تجاری آذرآبادگان، پلاک 1075 " + "</p><br/>" +
                             "<center><a href=""https://damapouyesh.com""  target=""_blank"" >" + "تعمیرات پکیج، کولر گازی، رادیاتور در تبریز" + "</a>  : <strong> 09144606572 - 04136628871</strong></center>"
                    Case "googleanalyticsid"
                        result = "G-ZTXD6KFVJN"

                    Case "lang"
                        result = "fa"
                    Case "dir"
                        result = "rtl"
                    Case "tel"
                        result = "+989144606572"


                End Select
            Case "ijk.ir"
                Select Case name.ToLower
                    Case "domainname"
                        result = "ijk.ir"
                    Case "fulldomainname"
                        result = "https://ijk.ir"

                    Case "folder"
                        result = "ijk"
                    Case "code"
                        result = "30005"
                    Case "title"
                        result = "سامانه خبری کنسرسیوم سامانه های تحت وب | آخرین مطالب علمی سامانه های تحت وب "
                    Case "keywords"
                        result = "سامانه های یکپارچه تحت وب , اپ استور تحت وب , فروشگاه سامانه های تحت وب , ijk , هتن , فروشگاه سامانه های تحت وب در تبریز"
                    Case "sitename"
                        result = "سامانه خبری فروشگاه سامانه های تحت وب ijk"
                    Case "sitefullname"
                        result = "سامانه خبری فروشگاه سامانه های تحت وب ijk"
                    Case "desc"
                        result = "فروشگاه نرم افزارهای تحت وب ijk"
                    Case "firstindex"
                        result = "1"
                    Case "social-link1"
                        result = "#"
                    Case "social-link2"
                        result = "#"
                    Case "social-link3"
                        result = "#"
                    Case "social-class1"
                        result = "fa fa-youtube"
                    Case "social-class2"
                        result = "fa fa-instagram"
                    Case "social-class3"
                        result = "fa fa-telegram"

                    Case "signature"
                        result = ""
                    Case "googleanalyticsid"
                        result = "G-DZZDHPP1L0"
                    Case "lang"
                        result = "fa"
                    Case "dir"
                        result = "rtl"
                    Case "tel"
                        result = "+989123127516"


                End Select

            Case "clinic.ijk.ir"
                Select Case name.ToLower
                    Case "domainname"
                        result = "clinic.ijk.ir"
                    Case "fulldomainname"
                        result = "https://clinic.ijk.ir"

                    Case "folder"
                        result = "clinic"

                    Case "code"
                        result = "10004"
                    Case "title"
                        result = "نرم افزار مدیریت و نوبت دهی مطب | بردار | clinic | bordar"
                    Case "keywords"
                        result = "نرم افزار مدیریت مطب,نوبت دهی مطب,ثبت نسخه الکترونیکی,ثبت پرونده الکترونیکی بیمار,ثبت پرونده بیمار,نوبت دهی آنلاین,نرم افزار آندروید بردار,نرم افزار مدیریت مطب بردار,bordar,نرم افزار مدیریت مطب در تبریز,در تبریز,نرم افزار مدیریت کلینیک در تبریز"
                    Case "sitename"
                        result = "نرم افزار مدیریت کلینیک و مطب"
                    Case "sitefullname"
                        result = "پایگاه اطلاع رسانی بردار"
                    Case "desc"
                        result = "مدیریت و نوبت دهی کلینیک و مطب "
                    Case "firstindex"
                        result = "1"
                    Case "social-link1"
                        result = "#"
                    Case "social-link2"
                        result = "#"
                    Case "social-link3"
                        result = "#"
                    Case "social-class1"
                        result = "fa fa-youtube"
                    Case "social-class2"
                        result = "fa fa-instagram"
                    Case "social-class3"
                        result = "fa fa-telegram"

                    Case "signature"
                        result = "<br/><b>" + "پشتیبانی نرم افزار بردار" + "</b>" +
                         "<p>" + "نرم افزار بردار یک برنامه مدیریت مطب، کلینیک ها و مراکز درمانی بزرگ است که جهت مدیریت بهینه، تسهیل و سهولت کار در مراکز درمانی ارائه شده است. " + "</p>" +
                                  "<p>" + "جهت اطلاعات بیشتر در مورد امکانات و قابلیت های نرم افزار بردار می توانید روی لینک زیر کلیک کنید ." + "</p>" +
                                  "<center><a href=""https://clinic.ijk.ir/main/""  target=""_blank"" >" + "بردار نرم افزار مدیریت مطب در تبریز" + "</a>  : 04133360935 - 09141011788 مهندس جهانی</center>"

                    Case "googleanalyticsid"
                        result = "G-6J7JFXWCPY"
                    Case "lang"
                        result = "fa"
                    Case "dir"
                        result = "rtl"
                    Case "tel"
                        result = "+989123127516"


                End Select
            Case "vam.ijk.ir"
                Select Case name.ToLower
                    Case "domainname"
                        result = "vam.ijk.ir"
                    Case "fulldomainname"
                        result = "https://vam.ijk.ir"

                    Case "folder"
                        result = "vam"

                    Case "code"
                        result = "30010"
                    Case "title"
                        result = "خرید وام ازدواج در تبریز"
                    Case "keywords"
                        result = "خرید وام ازدواج درتبریز,فروش وام ازدواج در تبریز"
                    Case "sitename"
                        result = "خرید وام ازدواج"
                    Case "sitefullname"
                        result = "خرید وام ازدواج"
                    Case "desc"
                        result = "خرید وام ازدواج"
                    Case "firstindex"
                        result = "1"
                    Case "social-link1"
                        result = "#"
                    Case "social-link2"
                        result = "#"
                    Case "social-link3"
                        result = "#"
                    Case "social-class1"
                        result = "fa fa-youtube"
                    Case "social-class2"
                        result = "fa fa-instagram"
                    Case "social-class3"
                        result = "fa fa-telegram"

                    Case "signature"
                        result = "<br/><b>" + "جهت فروش وام ازدواج خود به لینک زیر مراجعه فرمائید" + "</b>" +
                         "<p>" + "با تعهد محضری و معرفی ضامن های مورد نیاز و اخذ سفته . " + "</p>" +
                                  "<center><a href=""https://vam.ijk.ir/main/""  target=""_blank"" >" + "خرید وام ازدواج در تبریز" + "</a>  : 04133360935 - 09143147886 کریمی</center>"

                    Case "googleanalyticsid"
                        result = "G-6J7JFXWCPY"
                    Case "lang"
                        result = "fa"
                    Case "dir"
                        result = "rtl"
                    Case "tel"
                        result = "+989143147886"


                End Select

            Case "ardabilvam.ijk.ir"
                Select Case name.ToLower
                    Case "domainname"
                        result = "ardabilvam.ijk.ir"
                    Case "fulldomainname"
                        result = "https://ardabilvam.ijk.ir"

                    Case "folder"
                        result = "ardabilvam"

                    Case "code"
                        result = "30012"
                    Case "title"
                        result = "خرید وام ازدواج در اردبیل"
                    Case "keywords"
                        result = "خرید وام ازدواج دراردبیل,فروش وام ازدواج در اردبیل"
                    Case "sitename"
                        result = "خرید وفروش وام ازدواج در اردبیل"
                    Case "sitefullname"
                        result = "خرید وفروش وام ازدواج در اردبیل"
                    Case "desc"
                        result = "خرید وفروش وام ازدواج در اردبیل"
                    Case "firstindex"
                        result = "1"
                    Case "social-link1"
                        result = "#"
                    Case "social-link2"
                        result = "#"
                    Case "social-link3"
                        result = "#"
                    Case "social-class1"
                        result = "fa fa-youtube"
                    Case "social-class2"
                        result = "fa fa-instagram"
                    Case "social-class3"
                        result = "fa fa-telegram"

                    Case "signature"
                        result = "<br/><b>" + "جهت فروش وام ازدواج خود به لینک زیر مراجعه فرمائید" + "</b>" +
                         "<p>" + "با تعهد محضری و معرفی ضامن های مورد نیاز و اخذ سفته . " + "</p>" +
                                  "<center><a href=""https://ardabilvam.ijk.ir/main/""  target=""_blank"" >" + "خرید وام ازدواج در اردبیل" + "</a>  : 09123127516 - 989024242414 کریمی</center>"

                    Case "googleanalyticsid"
                        result = "G-6J7JFXWCPY"
                    Case "lang"
                        result = "fa"
                    Case "dir"
                        result = "rtl"
                    Case "tel"
                        result = "+989024242414"


                End Select

            Case "blog.altinkenti.com"
                Select Case name.ToLower
                    Case "domainname"
                        result = "blog.altinkenti.com"
                    Case "fulldomainname"
                        result = "https://blog.altinkenti.com"

                    Case "folder"
                        result = "altin"

                    Case "code"
                        result = "30007"
                    Case "title"
                        result = "altın ve mücevher dergisi"
                    Case "keywords"
                        result = "altın,mücevher"

                    Case "sitename"
                        result = "altin"
                    Case "sitefullname"
                        result = "altın ve mücevher dergisi"
                    Case "desc"
                        result = "altın ve mücevher dergisi"
                    Case "firstindex"
                        result = "1"
                    Case "social-link1"
                        result = "#"
                    Case "social-link2"
                        result = "#"
                    Case "social-link3"
                        result = "#"
                    Case "social-class1"
                        result = "fa fa-youtube"
                    Case "social-class2"
                        result = "fa fa-instagram"
                    Case "social-class3"
                        result = "fa fa-telegram"

                    Case "signature"
                        result = ""
                    Case "googleanalyticsid"
                        result = "G-DZZDHPP1L0"
                    Case "lang"
                        result = "tr"
                    Case "dir"
                        result = "ltr"
                    Case "tel"
                        result = "+989123127516"


                End Select
            Case "av.ijk.ir"
                Select Case name.ToLower
                    Case "domainname"
                        result = "av.ijk.ir"
                    Case "fulldomainname"
                        result = "https://av.ijk.ir"

                    Case "folder"
                        result = "av"

                    Case "code"
                        result = "10006"
                    Case "title"
                        result = "آنتی ویروس ایرانی بردار | آنتی ویروس تحت شبکه | bordar "
                    Case "keywords"
                        result = "آنتی ویروس,آنتی ویروس تحت شبکه,آنتی ویروس ایرانی,ضد ویروس,آنتی تروجان,قفل یو اس بی,بروز رسانی از سرور,در تبریز,آنتی ویروس با پنل مدیریت"

                    Case "sitename"
                        result = "آنتی ویروس بردار"
                    Case "sitefullname"
                        result = "پایگاه اطلاع رسانی آنتی ویروس بردار"
                    Case "desc"
                        result = "آنتی ویروس تحت شبکه یوز ، تحت شبکه با قابلیت مدیریت از ادمین"
                    Case "firstindex"
                        result = "1"
                    Case "social-link1"
                        result = "#"
                    Case "social-link2"
                        result = "#"
                    Case "social-link3"
                        result = "#"
                    Case "social-class1"
                        result = "fa fa-youtube"
                    Case "social-class2"
                        result = "fa fa-instagram"
                    Case "social-class3"
                        result = "fa fa-telegram"

                    Case "signature"
                        result = ""
                    Case "googleanalyticsid"
                        result = "G-DZZDHPP1L0"
                    Case "lang"
                        result = "fa"
                    Case "dir"
                        result = "rtl"
                    Case "tel"
                        result = "+989123127516"


                End Select

            Case "iweb.ijk.ir"
                Select Case name.ToLower
                    Case "domainname"
                        result = "iweb.ijk.ir"
                    Case "fulldomainname"
                        result = "https://iweb.ijk.ir"

                    Case "folder"
                        result = "iweb"

                    Case "code"
                        result = "30006"
                    Case "title"
                        result = "طراحی و بهینه سازی وب سایت در تبریز | طراحی سایت | iWeb | طراحی بازی آنلاین"
                    Case "keywords"
                        result = "طراحی سایت در تبریز,ساخت بازی آنلاین,ساخت سایت بازی آنلاین,طراحی سایت بازی آنلاین,طراحی بازی آنلاین,طراحی و ساخت بازی,طراحی و ساخت بازی آنلاین,راه اندازی سایت بازی آنلاین,راه اندازی و ساخت بازی آنلاین,سفارش بازی آنلاین,سفارش ساخت بازی آنلاین,سفارش طراحی و ساخت بازی,بازی کامپیوتری آنلاین,تولید بازی آنلاین,تولید سایت بازی آنلاین,فروش بازی آنلاین,ساخت بازی آنلاین در تبریز,بازی های آنلاین,بازی آنلاین دو نفره,بازی آنلاین بدون نصب,بازی آنلاین دو نفره از راه دور,بیلیارد,تخته نرد,بلک جک,21,پاسور,پوکر,حکم,انفجار,پیش بینی فوتبال"

                    Case "sitename"
                        result = "آی وب"
                    Case "sitefullname"
                        result = "طراحی سایت در تبریز"
                    Case "desc"
                        result = "آی وب طراحی و بهینه سازی وب سایت در تبریز"
                    Case "firstindex"
                        result = "1"
                    Case "social-link1"
                        result = "#"
                    Case "social-link2"
                        result = "#"
                    Case "social-link3"
                        result = "#"
                    Case "social-class1"
                        result = "fa fa-youtube"
                    Case "social-class2"
                        result = "fa fa-instagram"
                    Case "social-class3"
                        result = "fa fa-telegram"


                    Case "signature"
                        result = "<br/><b>" + "جهت طراحی وب سایت خود در این زمینه با ما تماس بگیرید" + "</b>" +
                         "<p>" + "با رزومه بسیار بالا در سطح کشور" + "</p>" +
                                  "<center><a href=""https://iweb.ijk.ir/main/""  target=""_blank"" >" + "طراحی سایت در تبریز" + "</a>  : 04133360935 - 09143147886 کریمی</center>"

                    Case "googleanalyticsid"
                        result = "G-DZZDHPP1L0"
                    Case "lang"
                        result = "fa"
                    Case "dir"
                        result = "rtl"
                    Case "tel"
                        result = "+989123127516"


                End Select
            Case "uis.ijk.ir"
                Select Case name.ToLower
                    Case "domainname"
                        result = "uis.ijk.ir"
                    Case "fulldomainname"
                        result = "https://uis.ijk.ir"

                    Case "folder"
                        result = "uis"
                    Case "code"
                        result = "2"
                    Case "title"
                        result = " سامانه های جامع دانشجویی | اخبار سامانه های نرم افزاری دانشگاه | کارت جامع دانشجویی"
                    Case "keywords"
                        result = "کارت دانشجویی,کارت جامع دانشجویی,سامانه های دانشگاه,سامانه های رفاهی دانشجویی,اتوماسیون تغذیه,اتوماسیون کتابخانه,کارت تغذیه,کنترل تردد,uis,عهس,نرم افزار مدیریت سایت کامپیوتری,نرم افزار استخر,نرم افزار باشگاه ورزشی"
                    Case "sitename"
                        result = "کارت جامع دانشجویی"
                    Case "sitefullname"
                        result = "پایگاه خبری سامانه های کارت جامع دانشجویی"
                    Case "desc"
                        result = "خبرهای دانشگاهی و سامانه های  کارت جامع دانشجویی"
                    Case "firstindex"
                        result = "1"
                    Case "social-link1"
                        result = "#"
                    Case "social-link2"
                        result = "#"
                    Case "social-link3"
                        result = "#"
                    Case "social-class1"
                        result = "fa fa-youtube"
                    Case "social-class2"
                        result = "fa fa-instagram"
                    Case "social-class3"
                        result = "fa fa-telegram"

                    Case "signature"
                        result = ""
                    Case "googleanalyticsid"
                        result = "G-DZZDHPP1L0"
                    Case "lang"
                        result = "fa"
                    Case "dir"
                        result = "rtl"
                    Case "tel"
                        result = "+989123127516"

                End Select

        End Select

        Return result
    End Function
    Public Shared Function GetStandardLink(title As String) As String
        Return title.Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Replace(" ", "-")
    End Function

    Public Shared Function solrSearch(lable As String, Optional Count As Integer = 10) As Data.DataTable
        Dim prjobj As New prj
        Startup.InitContainer()
        Startup.Init(Of prj)(prjobj.server)
        Dim solr = ServiceLocator.Current.GetInstance(Of ISolrOperations(Of prj))()
        Dim op1 As New QueryOptions
        Dim array() As String = {"cityname"} ', "title", "group", "tags", "description"}
        Dim params As System.Collections.Generic.IEnumerable(Of String) = array

        ' Cast the array to IEnumerable reference.

        Dim MoreLikeThisParameters1 As New MoreLikeThisParameters(params)
        MoreLikeThisParameters1.MinDocFreq = 1
        MoreLikeThisParameters1.MinTermFreq = 1

        op1.MoreLikeThis = MoreLikeThisParameters1
        op1.Rows = Count
        lable = lable.Replace("+", " ")

        Dim sq As SolrQuery
        sq = New SolrQuery(lable)

        Dim results = solr.Query(sq, op1)
        Dim resultStr As String = ""
        Dim tbl As New Data.DataTable
        tbl.Columns.Add("prjid")
        tbl.Columns.Add("tags")
        tbl.Columns.Add("title")
        tbl.Columns.Add("description")
        tbl.Columns.Add("cityName")
        tbl.Columns.Add("group")
        tbl.Columns.Add("Radif")
        Dim radif As Integer = 0
        Dim r, similar
        For Each r In results

            'resultStr = vbCrLf + "Similar documents to " + r.v.newscode + ":"
            Dim dr As Data.DataRow = tbl.NewRow
            dr("Radif") = radif
            radif += 1
            dr("prjid") = r.prjid.ToString
            dr("tags") = r.tags
            dr("description") = r.description
            dr("cityname") = r.cityname
            dr("group") = r.group
            dr("title") = r.title
            tbl.Rows.Add(dr)
        Next

        Return tbl
    End Function
    Public Shared Sub solrInsert(prjid As String, tags As String, title As String, desc As String, cityName As String, group As String)
        Dim prjobj As New prj
        prjobj.prjid = prjid
        prjobj.title = title
        prjobj.description = desc
        prjobj.tags = tags
        prjobj.cityname = cityName
        prjobj.group = group
        Startup.InitContainer()
        Startup.Init(Of prj)(prjobj.server)
        Dim solr = ServiceLocator.Current.GetInstance(Of ISolrOperations(Of prj))()
        solr.Add(prjobj)
        solr.Commit()
    End Sub
    Public Shared Sub solrDelById(prjid As String)
        Dim query = New SolrQuery(" prjid=" + prjid)
        Dim prjobj As New prj

        Startup.InitContainer()
        Startup.Init(Of prj)(prjobj.server)
        Dim solr = ServiceLocator.Current.GetInstance(Of ISolrOperations(Of prj))()
        solr.Delete(query)
        solr.Commit()
    End Sub

    Public Shared Function WebgardiCount() As Integer
        Return 4

    End Function
    Public Shared Function change4DropDwoen(str As String) As String
        If str = "انتخاب نمائید" Then
            Return "انخاب نشده"
        End If
        Return str
    End Function
    Public Shared Function GetDateSpan(t As String) As String
        Dim insertDate As Date = Convert.ToDateTime(t)
        Dim span As TimeSpan = Now.Subtract(insertDate)
        Dim str As String = ""
        If span.Days > 30 Then
            str += CInt(span.Days / 30).ToString + " ماه  " + "پیش"
            Return str
        End If
        If span.Days > 7 Then
            str += CInt(span.Days / 7).ToString + " هفته  " + "پیش"
            Return str
        End If

        If span.Days > 0 Then
            str += span.Days.ToString + " روز  " + "پیش"
            Return str
        End If
        If span.Hours > 0 Then
            str += span.Hours.ToString + " ساعت  " + "پیش"
            Return str
        End If
        If span.Minutes > 0 Then
            str += span.Minutes.ToString + " دقیقه  " + "پیش"
            Return str
        End If

        str = "لحظاتی " + "پیش"

        Return str
    End Function
    Public Shared Function SendMail(title As String, html As String, mailto As String) As String
        Try

            Dim mail As New MailMessage()



            html += "</html>"
            '<img src=cid:logo>


            mail.From = New MailAddress("info@kichio.ir")
            mail.To.Add(mailto)
            mail.Subject = title
            mail.Body = html
            mail.IsBodyHtml = True
            mail.BodyEncoding = System.Text.Encoding.UTF8
            mail.SubjectEncoding = System.Text.Encoding.UTF8
            Dim nonHtml As String = html.Replace("<html>", "").Replace("</html>", "").Replace("<br/>", "").Replace("<br />", "")
            mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(nonHtml, Nothing, MediaTypeNames.Text.Plain))



            'Dim logo As New Attachment(HttpContext.Current.Server.MapPath("logo2.png"), MediaTypeNames.Image.Jpeg)
            'logo.ContentId = "logo"
            'logo.ContentDisposition.Inline = True
            'logo.ContentDisposition.DispositionType = DispositionTypeNames.Inline
            'mail.Attachments.Add(logo)


            Dim SmtpServer As New SmtpClient()
            SmtpServer.UseDefaultCredentials = False
            SmtpServer.Credentials = New Net.NetworkCredential("info@kichio.ir", "Pass_2494")
            SmtpServer.Timeout = 20000
            SmtpServer.EnableSsl = False
            SmtpServer.Port = 25 '587
            SmtpServer.Host = "kichio.ir" '"smtp.zoho.com"
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network
            SmtpServer.Send(mail)

        Catch ex As Exception
            Return ex.Message
        End Try
        Return ""
    End Function




    Public Shared Sub setGridStyle(ByRef grid As GridView, Optional ByVal styleType As String = "Silver")
        Select Case styleType
            Case "Silver"
                grid.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                grid.GridLines = GridLines.Both
                grid.BorderColor = Drawing.Color.White
                grid.BorderStyle = BorderStyle.Solid
                grid.BorderWidth = 2

                grid.Font.Size = 10
                grid.CaptionAlign = HorizontalAlign.Center

                grid.CssClass = "myGrid"
                grid.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                grid.HeaderStyle.BackColor = Drawing.Color.Gainsboro
                grid.HeaderStyle.ForeColor = Drawing.Color.Black
                grid.HeaderStyle.CssClass = "GridRowStyle"

                grid.RowStyle.HorizontalAlign = HorizontalAlign.Center
                grid.RowStyle.BackColor = Drawing.Color.WhiteSmoke
                grid.RowStyle.ForeColor = Drawing.Color.Black
                grid.RowStyle.VerticalAlign = VerticalAlign.Middle
                grid.RowStyle.BorderColor = Drawing.Color.White
                grid.RowStyle.BorderStyle = BorderStyle.Solid
                grid.RowStyle.CssClass = "GridRowStyle"
                grid.RowStyle.BorderWidth = 2

                grid.AlternatingRowStyle.BackColor = Drawing.Color.Gainsboro
                grid.AlternatingRowStyle.ForeColor = Drawing.Color.Black
                grid.AlternatingRowStyle.VerticalAlign = VerticalAlign.Middle


        End Select

    End Sub
    Public Shared Function StripHTML(ByVal source As String) As String
        Try
            Dim result As String
            Dim i, j As Integer
            ' Remove HTML Development formatting
            ' Replace line breaks with space
            ' because browsers inserts space
            result = source.Replace(vbCr, " ")
            ' Replace line breaks with space
            ' because browsers inserts space
            result = result.Replace(vbLf, " ")
            ' Remove step-formatting
            result = result.Replace(vbTab, String.Empty)
            ' Remove repeating spaces because browsers ignore them
            result = System.Text.RegularExpressions.Regex.Replace(result, "( )+", " ")

            ' Remove the header (prepare first by clearing attributes)
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*head([^>])*>", "<head>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "(<( )*(/)( )*head( )*>)", "</head>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "(<head>).*(</head>)", String.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' remove all scripts (prepare first by clearing attributes)
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*script([^>])*>", "<script>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "(<( )*(/)( )*script( )*>)", "</script>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            'result = System.Text.RegularExpressions.Regex.Replace(result,
            '         @"(<script>)([^(<script>\.</script>)])*(</script>)",
            '         string.Empty,
            '         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            '  result = System.Text.RegularExpressions.Regex.Replace(result, "(<script>).*(</script>)", String.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' remove all styles (prepare first by clearing attributes)
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*style([^>])*>", "<style>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "(<( )*(/)( )*style( )*>)", "</style>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "(<style>).*(</style>)", String.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' insert tabs in spaces of <td> tags
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*td([^>])*>", vbTab, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' insert line breaks in places of <BR> and <LI> tags
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*br( )*>", "_", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*li( )*>", "_", System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' insert line paragraphs (double line breaks) in place
            ' if <P>, <DIV> and <TR> tags
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*div([^>])*>", vbCr & vbCr, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*tr([^>])*>", vbCr & vbCr, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*p([^>])*>", vbCr & vbCr, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' Remove remaining tags like <a>, links, images,
            ' comments etc - anything that's enclosed inside < >
            result = System.Text.RegularExpressions.Regex.Replace(result, "<[^>]*>", "_", System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' replace special characters:
            result = System.Text.RegularExpressions.Regex.Replace(result, " ", " ", System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            result = System.Text.RegularExpressions.Regex.Replace(result, "&bull;", " * ", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&lsaquo;", "<", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&rsaquo;", ">", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&trade;", "(tm)", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&frasl;", "/", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&lt;", "<", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&gt;", ">", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&copy;", "(c)", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&reg;", "(r)", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            ' Remove all others. More can be added, see
            ' http://hotwired.lycos.com/webmonkey/reference/special_characters/
            result = System.Text.RegularExpressions.Regex.Replace(result, "&(.{2,6});", String.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' for testing
            'System.Text.RegularExpressions.Regex.Replace(result,
            '       this.txtRegex.Text,string.Empty,
            '       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            ' make line breaking consistent
            result = result.Replace(vbLf, vbCr)

            ' Remove extra line breaks and tabs:
            ' replace over 2 breaks with 2 and over 4 tabs with 4.
            ' Prepare first to remove any whitespaces in between
            '' the escaped characters and remove redundant tabs in between line breaks
            'result = System.Text.RegularExpressions.Regex.Replace(result, "(" & vbCr & ")( )+(" & vbCr & ")", vbCr & vbCr, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            'result = System.Text.RegularExpressions.Regex.Replace(result, "(" & vbTab & ")( )+(" & vbTab & ")", vbTab & vbTab, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            'result = System.Text.RegularExpressions.Regex.Replace(result, "(" & vbTab & ")( )+(" & vbCr & ")", vbTab & vbCr, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            'result = System.Text.RegularExpressions.Regex.Replace(result, "(" & vbCr & ")( )+(" & vbTab & ")", vbCr & vbTab, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            '' Remove redundant tabs
            'result = System.Text.RegularExpressions.Regex.Replace(result, "(" & vbCr & ")(" & vbTab & ")+(" & vbCr & ")", vbCr & vbCr, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            '' Remove multiple tabs following a line break with just one tab
            'result = System.Text.RegularExpressions.Regex.Replace(result, "(" & vbCr & ")(" & vbTab & ")+", vbCr & vbTab, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            '' Initial replacement target string for line breaks
            'Dim breaks As String = vbCr & vbCr & vbCr
            '' Initial replacement target string for tabs
            'Dim tabs As String = vbTab & vbTab & vbTab & vbTab & vbTab
            'For index As Integer = 0 To result.Length - 1
            '    result = result.Replace(breaks, vbCr & vbCr)
            '    result = result.Replace(tabs, vbTab & vbTab & vbTab & vbTab)
            '    breaks = breaks & vbCr
            '    tabs = tabs & vbTab
            'Next
            result = System.Text.RegularExpressions.Regex.Replace(result, "[\u003C-\u007F]", "_")
            result = System.Text.RegularExpressions.Regex.Replace(result, "[\u0023-\u0026]", "_")
            result = System.Text.RegularExpressions.Regex.Replace(result, "[\u002A-\u002D]", "_")
            result = result.Replace(vbCr, "_")
            result = result.Replace(vbTab, "_")
            Dim str() As String = result.Split("_")
            result = ""
            Dim last As Integer = 0
            Dim lasti As Integer = 0
            For i = 0 To str.Length - 1
                If str(i).Length >= 150 Then
                    For j = 4 To 1 Step -1
                        If str(i - j).Length < 150 And str(i - j).Length > 10 And last < i - j Then
                            result += "<p ><strong>" + str(i - j) + "</strong></p>"
                            last = i - j

                        End If

                    Next
                    result += "<p>" + str(i) + "</p>"
                    lasti = i
                End If
            Next
            For i = lasti + 1 To lasti + 2
                If str(i).Length < 150 And str(i).Length > 10 Then
                    result += "<p >" + str(i) + "</p>"
                End If
            Next
            ' That's it.
            'If result.Length < 50 Then
            '    For i As Integer = 0 To 60
            '        result += " "
            '    Next
            'End If
            Return result

        Catch
            If source.Length < 50 Then
                For i As Integer = 0 To 60
                    source += " "
                Next
            End If
            Return source
        End Try
    End Function
    Public Shared Function RempveSpecialChars(ByVal input As String) As String
        input = input.Replace(" ", "-").Replace("/", "-").Replace("\", "-").Replace(":", "-").Replace(".", "-") _
        .Replace("+", "-").Replace("&zwnj", "-").Replace("&laquo", "-").Replace("&raquo", "-").Replace("&lsaquo", "-") _
        .Replace("&rsaquo", "-").Replace("&lt", "-").Replace("&gt", "-").Replace("&frasl", "-") _
        .Replace("&#8211", "-").Replace("&#8212", "-") _
        .Replace("&#8216", "-").Replace("&#8217", "-").Replace("&#8218", "-") _
        .Replace("&#8220", "-").Replace("&#8221", "-").Replace("&#8222", "-") _
        .Replace("&#8226", "-").Replace("&#8230", "-") _
        .Replace("&bull", "-").Replace("""", "").Replace("&quot;", "").Replace(";", "-") _
        .Replace("---", "-").Replace("--", "-")
        Return input
    End Function
    'Dim Query As Query
    Public Shared EncKey As String = "!#@&$"
    Dim DataSet As Data.DataSet
    Dim News As String
    Public Shared Function NavigationParaneters() As String
        Return "CMSCode=" + HttpContext.Current.Request.QueryString("CMSCode") + "&PageCode=" + HttpContext.Current.Request.QueryString("PageCode")
    End Function

    'Redirect To Another Frame
    'Public Shared Function QueryString(ByVal param As String) As String
    '    If HttpContext.Current.Request.QueryString(param) IsNot Nothing Then
    '        Return (HttpContext.Current.Request.QueryString(param))
    '        Exit Function
    '    End If
    '    Dim p As String = HttpContext.Current.Request.QueryString("p")

    '    If p Is Nothing Then
    '        HttpContext.Current.Response.Redirect("~/aa.aspx")
    '    End If
    '    Dim enc As New Encryption.Utils
    '    Dim Key As String = EncKey  'HttpContext.Current.Request.QueryString("rnd")
    '    Dim Params As String() = enc.Decrypt(p, Key).ToString.Split(";")
    '    For Each item As String In Params
    '        Dim itemArray As String() = item.Split("=")
    '        If itemArray(0).ToLower = param.ToLower Then
    '            Return itemArray(1)
    '            Exit Function

    '        End If
    '    Next
    '    Return Nothing
    'End Function

    Public Shared Function FindArray(ByVal input As String(), ByVal key As String) As String
        If input Is Nothing Then
            Return Nothing
            Exit Function
        End If
        For i As Integer = 0 To input.Length - 1
            If input(i).Split("=")(0).ToLower = key.ToLower Then
                Return input(i).Split("=")(1).ToLower
                Exit Function
            End If
        Next
        Return Nothing
    End Function
    'Public Shared Sub Redirect(ByVal url As String, Optional ByVal endResponse As Boolean = False)

    '    Dim tmp As String = ""
    '    If url.LastIndexOf("?") <> -1 Then

    '        tmp = url.Substring(url.LastIndexOf("?") + 1)

    '    End If
    '    Dim inputQuery() As String
    '    If tmp <> "" Then
    '        inputQuery = tmp.Split("&")
    '    End If
    '    Dim enc As New Encryption.Utils
    '    Dim Query As String = ""
    '    Dim params() As String = enc.Decrypt(HttpContext.Current.Request.QueryString("p"), EncKey).ToString.Split(";")
    '    For Each item As String In params
    '        Dim qArray() As String = item.Split("=")

    '        If qArray(0).ToLower = "cmscode" Or qArray(0).ToLower = "db" Or qArray(0).ToLower = "lang" Or qArray(0).ToLower = "pagecode" Or qArray(0).ToLower = "template" Then
    '            If FindArray(inputQuery, qArray(0).ToLower) IsNot Nothing Then
    '                Query += qArray(0) + "=" + FindArray(inputQuery, qArray(0).ToLower)
    '                'inputQuery.Find(inputQuery, item)
    '            Else
    '                Query += item
    '            End If
    '            Query += ";"
    '        End If
    '    Next

    '    If inputQuery IsNot Nothing Then
    '        For Each item As String In inputQuery
    '            Dim itemArray As String() = item.Split("=")
    '            If itemArray(0).ToLower <> "cmscode" And _
    '                itemArray(0).ToLower <> "db" And itemArray(0).ToLower <> "lang" And _
    '                itemArray(0).ToLower <> "p" And itemArray(0).ToLower <> "pagecode" And itemArray(0).ToLower <> "template" Then
    '                Query += item
    '                Query += ";"
    '            End If
    '        Next


    '        HttpContext.Current.Response.Redirect(url.Substring(0, url.IndexOf("?")) + "?p=" + (New Encryption.Utils).Encrypt(Query, General.EncKey))
    '    Else
    '        HttpContext.Current.Response.Redirect(url + "?p=" + (New Encryption.Utils).Encrypt(Query, General.EncKey))
    '    End If


    'End Sub

    'Public Shared Sub Redirect1(ByVal url As String, Optional ByVal endResponse As Boolean = False)
    '    Dim tmp As String = ""
    '    If url.LastIndexOf("?") <> -1 Then

    '        tmp = url.Substring(url.LastIndexOf("?") + 1)

    '    End If
    '    Dim inputQuery() As String
    '    If tmp <> "" Then
    '        inputQuery = tmp.Split("&")
    '    End If
    '    Dim enc As New Encryption.Utils
    '    Dim Query As String = ""
    '    Dim params() As String = enc.Decrypt(HttpContext.Current.Request.QueryString("p"), EncKey).ToString.Split(";")
    '    For Each item As String In params
    '        Dim qArray() As String = item.Split("=")

    '        If qArray(0).ToLower = "cmscode" Or qArray(0).ToLower = "db" Or qArray(0).ToLower = "lang" Or qArray(0).ToLower = "pagecode" Or qArray(0).ToLower = "template" Then
    '            If FindArray(inputQuery, qArray(0).ToLower) IsNot Nothing Then
    '                Query += qArray(0) + "=" + FindArray(inputQuery, qArray(0).ToLower)
    '            Else
    '                Query += item
    '            End If
    '            Query += ";"
    '        End If
    '    Next

    '    If inputQuery IsNot Nothing Then
    '        For Each item As String In inputQuery
    '            Dim itemArray As String() = item.Split("=")
    '            If itemArray(0).ToLower <> "cmscode" And itemArray(0).ToLower <> "db" And itemArray(0).ToLower <> "lang" And itemArray(0).ToLower <> "p" And itemArray(0).ToLower = "template" Then
    '                Query += item
    '                Query += ";"
    '            End If
    '        Next
    '        HttpContext.Current.Response.Redirect(url.Substring(0, url.IndexOf("?")) + "?p=" + (New Encryption.Utils).Encrypt(Query, General.EncKey))
    '    Else
    '        HttpContext.Current.Response.Redirect(url + "?p=" + (New Encryption.Utils).Encrypt(Query, General.EncKey))
    '    End If


    'End Sub
    Function GetHTML(ByVal strPage As String, ByVal EncodingCode As Integer) As String
        Dim strReply As String = "NULL"
        'Dim objErr As ErrObject
        Try
            Dim objHttpRequest As System.Net.HttpWebRequest
            Dim objHttpResponse As System.Net.HttpWebResponse
            objHttpRequest = System.Net.HttpWebRequest.Create(strPage)
            objHttpResponse = objHttpRequest.GetResponse
            Dim objStrmReader As IO.StreamReader

            objStrmReader = New IO.StreamReader(objHttpResponse.GetResponseStream, System.Text.Encoding.GetEncoding(EncodingCode), True)
            strReply = objStrmReader.ReadToEnd()

        Catch ex As Exception
            strReply = "ERROR! " + ex.Message.ToString
        End Try

        Return strReply

    End Function
    Public Function GetImage(ByVal BeforImage As String, ByVal AfterImage As String, ByVal InputURL As String, ByVal ImageURL As String, ByVal EncodingCode As Integer) As String
        Try
            Dim Html As String
            Dim Url As String
            Dim Temp As String
            Html = GetHTML(InputURL, EncodingCode)
            Dim BeforImageIndex As Int64 = Html.IndexOf(BeforImage)
            Temp = Html.Substring(BeforImageIndex)
            BeforImageIndex = Temp.IndexOf(BeforImage)
            Dim AfterImageIndex As Int64 = Temp.IndexOf(AfterImage)

            Url = Temp.Substring(BeforImageIndex + BeforImage.Length, AfterImageIndex - BeforImageIndex - BeforImage.Length)
            If Url.ToLower.IndexOf("http") = -1 Then
                Url = ImageURL + Url
            End If
            Return Url

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Public Function GetBody(ByVal BeforBody As String, ByVal AfterBody As String, ByVal InputURL As String, ByVal EncodingCode As Integer) As String
        Dim Html As String
        Dim Body As String
        Dim Temp As String
        Try
            Html = GetHTML(InputURL, EncodingCode)
            Dim BeforImageIndex As Int64 = Html.IndexOf(BeforBody)
            Temp = Html.Substring(BeforImageIndex)
            BeforImageIndex = Temp.IndexOf(BeforBody)
            Dim AfterImageIndex As Int64 = Temp.IndexOf(AfterBody)

            ' Body = Temp.Substring(BeforImageIndex, AfterImageIndex - BeforImageIndex)
            Body = Temp.Substring(BeforImageIndex + BeforBody.Length, AfterImageIndex - BeforImageIndex - BeforBody.Length)
            Dim ImageIndex As Int64 = Body.IndexOf("img")
            If ImageIndex > 0 Then
                Body = Body.Insert(ImageIndex + 3, " style=""display:none;"" ")
            End If
            Return Body

        Catch ex As Exception

        End Try



    End Function
    Public Shared Function toPersianSQL(ByVal SQLstr As String) As String

        SQLstr = SQLstr.Replace("ي", "ی")

        SQLstr = SQLstr.Replace("ی", "[یي]")

        SQLstr = SQLstr.Replace("ك", "ک")

        SQLstr = SQLstr.Replace("ک", "[کك]")

        Return SQLstr.Trim

    End Function

    Public Function PopupWindowWithoutEvent(ByVal Url As String, Optional ByVal scrollbars As String = "0", Optional ByVal height As String = "550", Optional ByVal width As String = "800") As String
        Dim Script As String
        Script = "<SCRIPT LANGUAGE=""JavaScript"">"
        Script = Script + "  window.open("""
        Script = Script + "" + Url
        'Script = Script + """,""aaa"","""")"
        Script = Script + """,""aaa"",""scrollbars=" + IIf(scrollbars = "0", "no", "yes") + ",menubar=no ,height=" + height + ",width=" + width + ",left=0,top=0,resizable=no,fullscreen=no"") "
        Script = Script + "  </script>"

        Return Script
    End Function
    Public Function PopupWindow(ByVal Url As String) As String
        Dim Script As String
        Script = "  window.open("""
        Script = Script + "" + Url
        Script = Script + ""","""",""scrollbars=yes,menubar=no ,height=750,width=1024,left=0,top=0,resizable=yes,statusbar=no,fullscreen=no"");   "

        Return Script
    End Function
    Public Function PopupWindowViaScroll(ByVal Url As String) As String
        Dim Script As String
        Script = "  window.open("""
        Script = Script + "" + Url
        'Script = Script + """,""aaa"","""")"
        Script = Script + """,""aaa"",""status=1,menubar=no ,height=550,width=800,left=100,top=80,resizable=no,statusbar=no,fullscreen=yes"")   "

        Return Script
    End Function
    Public Shared Function ModalWindowViaScroll(ByVal Url As String, Optional ByVal width As String = "800", Optional ByVal height As String = "600") As String
        Dim script As String = "window.showModalDialog(""{0}"","""",""dialogHeight: {2}px; dialogWidth: {1}px;  edge: Raised; center: Yes; resizable: Yes; status: No;"");"
        script = String.Format(script, Url, width, height)


        Return script
    End Function
    Public Function PopupWindowHide(ByVal Url As String) As String
        Dim Script As String
        Script = "  window.open("""
        Script = Script + "" + Url
        'Script = Script + """,""aaa"","""")"
        Script = Script + """,""aaa"",""menubar=no ,height=10,width=480,left=100,top=80,resizable=no,statusbar=no,fullscreen=no"")   "

        Return Script
    End Function

    Public Function Message(ByVal MessageText As String) As String
        Dim MessageScript As String = ""
        If Not MessageText Is Nothing Then

            MessageScript = "<SCRIPT LANGUAGE=""JavaScript"">"
            MessageScript = MessageScript + "  alert("" " + MessageText + " "") "
            MessageScript = MessageScript + "  </script>"
        End If
        Return MessageScript

    End Function
    Public Function Confirm(ByVal MessageText As String) As String
        Dim MessageScript As String = ""
        If Not MessageText Is Nothing Then

            MessageScript = "<SCRIPT LANGUAGE=""JavaScript"">" &
            " var ans;ans=window.confirm('" + MessageText + "'); " &
            " if (ans==true) 	{	document.form1.Temp.value='Yes';    } " &
            " else { 		document.form1.Temp.value='No';	} " &
            " </script>"
        End If
        Return MessageScript

    End Function

    ' تنظيم log و kartabl براي عمل مورد نظر
    'Public Sub SetSanadLog(ByRef SanadLog As SanadLog, ByVal SanadCode As String, ByVal UserCode As String, ByVal ActionCode As String, ByVal OfficeCode As String, ByVal Description As String, ByVal ExtraID As String, ByVal SetKartabl As Status.Kartabl, ByVal KartablId As String, Optional ByVal Status As String = "1")
    '    Try
    '        SanadLog.SanadCode = SanadCode
    '        SanadLog.UserCode = UserCode
    '        SanadLog.ActionCode = ActionCode
    '        SanadLog.Status = Status
    '        SanadLog.OfficeCode = OfficeCode
    '        SanadLog.Description = Description
    '        SanadLog.ExtraID = ExtraID
    '        SanadLog.SetKartabl = SetKartabl
    '        If KartablId <> Nothing Then
    '            SanadLog.KartablId = KartablId
    '        Else
    '            SanadLog.KartablId = 0
    '        End If
    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Function GetNewsTitle() As String
    '    Try
    '        Me.dataSet = New Data.DataSet
    '        News = ""

    '        Me.dataSet = Me.Query.Read.GetNewsTitles("1")
    '        Dim i As Integer = 0
    '        For i = 0 To Me.dataSet.Tables("NewsTitles").Rows.Count - 1
    '            Me.News += "<br/><a class=link-text  href=" + Me.DataSet.Tables("NewsTitles").Rows(i).Item("Href") + " target= " + Me.DataSet.Tables("NewsTitles").Rows(i).Item("Target") & _
    '            "><span style= " + "" + Me.DataSet.Tables("NewsTitles").Rows(i).Item("TitleStyle") + ">" + Me.DataSet.Tables("NewsTitles").Rows(i).Item("Title") + "</span>"
    '            Me.News += "<span style= " + "" + Me.DataSet.Tables("NewsTitles").Rows(i).Item("DateStyle") + "> - " + Me.DataSet.Tables("NewsTitles").Rows(i).Item("ShamsiDate") + "</span></a><br/>"


    '        Next

    '        Return News
    '    Catch ex As Exception
    '        Return Nothing
    '    Finally
    '        Me.DataSet.Dispose()

    '    End Try

    'End Function
    'Function WriteNews() As String
    '    Try
    '        Me.DataSet = New Data.DataSet
    '        News = ""
    '        Me.DataSet = Me.Query.Read.GetNewsBody("3")
    '        Dim i As Integer = 0
    '        For i = 0 To Me.DataSet.Tables("NewsBody").Rows.Count - 1
    '            Me.News += "</br><P align=right style=""color:Red "">" + Me.DataSet.Tables("NewsBody").Rows(i).Item("Title") + "</p></br><P align=right style=""color:black "">" + Me.DataSet.Tables("NewsBody").Rows(i).Item("NewsBody") + "</p><hr />"


    '        Next
    '        Return News
    '    Catch ex As Exception
    '        Return Nothing
    '    Finally
    '        Me.DataSet.Dispose()

    '    End Try

    'End Function
    ''''''''''''''''''''''''برای تبدیل DataTable    به کد
    Public Shared Function DBNULL(ByVal input As Object, Optional ByVal NullValue As String = "") As String
        If IsDBNull(input) Then
            Return NullValue
        Else
            Return input
        End If
    End Function
    Public Shared Sub SelectGridRow(ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs,
            ByRef GridView As GridView, Optional ByVal MouseOverColor As String = "Silver",
            Optional ByVal MouseOutColor As String = "white", Optional ByVal HasMasterPage As Boolean = True,
            Optional ByVal ContetPlaceHolderName As String = "ContentPlaceHolder1")
        If HasMasterPage = True Then
            If e.Row.RowType = ListItemType.Item Or
                e.Row.RowType = ListItemType.AlternatingItem Then
                e.Row.Attributes.Add("onmouseover", "Gridcolor=this.style.backgroundColor;this.style.backgroundColor='" + MouseOverColor + "';this.style.cursor='hand'")
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=Gridcolor;this.style.cursor='default'")
                Dim Click As String
                Click = "__doPostBack('ctl00$" + ContetPlaceHolderName + "$" + GridView.ID + "$ctl"
                If GridView.AllowPaging = True Then
                    Click += IIf((e.Row.RowIndex + 3) < 10, "0" + (e.Row.RowIndex + 3).ToString, (e.Row.RowIndex + 3).ToString)
                Else
                    Click += IIf((e.Row.RowIndex + 3) < 10, "0" + (e.Row.RowIndex + 2).ToString, (e.Row.RowIndex + 2).ToString)
                End If
                Click += "$ctl00','')"
                e.Row.Attributes.Add("onclick", Click)
            End If
        Else

            e.Row.Attributes.Add("onmouseover", "Gridcolor=this.style.backgroundColor;this.style.backgroundColor='" + MouseOverColor + "';this.style.cursor='hand'")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=Gridcolor;this.style.cursor='default'")
            Dim Click As String
            Click = "__doPostBack('" + GridView.ID + "$ctl"
            If GridView.AllowPaging = True Then
                Click += IIf((e.Row.RowIndex + 3) < 10, "0" + (e.Row.RowIndex + 3).ToString, (e.Row.RowIndex + 3).ToString)
            Else
                Click += IIf((e.Row.RowIndex + 3) < 10, "0" + (e.Row.RowIndex + 2).ToString, (e.Row.RowIndex + 2).ToString)
            End If
            Click += "$ctl00','')"
            e.Row.Attributes.Add("onclick", Click)
        End If


    End Sub
    Public Sub SelectGridRow(ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs, ByRef DataGrid As DataGrid, Optional ByVal MouseOverColor As String = "Silver", Optional ByVal MouseOutColor As String = "white", Optional ByVal HasMasterPage As Boolean = False)
        Try
            If HasMasterPage = True Then
                If e.Item.ItemType = ListItemType.Item Or
                    e.Item.ItemType = ListItemType.AlternatingItem Then
                    e.Item.Attributes.Add("onmouseover", "Gridcolor=this.style.backgroundColor;this.style.backgroundColor='" + MouseOverColor + "';this.style.cursor='hand'")
                    e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=Gridcolor;this.style.cursor='default'")
                    Dim Click As String
                    Click = "__doPostBack('ctl00$ContentPlaceHolder1$" + DataGrid.ID + "$ctl"
                    If DataGrid.AllowPaging = True Then
                        Click += IIf((e.Item.ItemIndex + 3) < 10, "0" + (e.Item.ItemIndex + 3).ToString, (e.Item.ItemIndex + 3).ToString)
                    Else
                        Click += IIf((e.Item.ItemIndex + 3) < 10, "0" + (e.Item.ItemIndex + 2).ToString, (e.Item.ItemIndex + 2).ToString)
                    End If
                    Click += "$ctl00','')"
                    e.Item.Attributes.Add("onclick", Click)
                End If
            Else
                If e.Item.ItemType = ListItemType.Item Or
                e.Item.ItemType = ListItemType.AlternatingItem Then
                    e.Item.Attributes.Add("onmouseover", "Gridcolor=this.style.backgroundColor;this.style.backgroundColor='" + MouseOverColor + "';this.style.cursor='hand'")
                    e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=Gridcolor;this.style.cursor='default'")
                    Dim Click As String
                    Click = "__doPostBack('" + DataGrid.ID + "$ctl"
                    If DataGrid.AllowPaging = True Then
                        Click += IIf((e.Item.ItemIndex + 3) < 10, "0" + (e.Item.ItemIndex + 3).ToString, (e.Item.ItemIndex + 3).ToString)
                    Else
                        Click += IIf((e.Item.ItemIndex + 3) < 10, "0" + (e.Item.ItemIndex + 2).ToString, (e.Item.ItemIndex + 2).ToString)
                    End If
                    Click += "$ctl00','')"
                    e.Item.Attributes.Add("onclick", Click)
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
    Public Function NewFile() As String
        Dim Str As String
        Str =
            "<script language=""javascript""> alert('پرونده جدیدی به کارتابل کاری شما اضافه شده است'); </script>"
        Return Str
    End Function
    Function ClosePage() As String
        Dim Script As String
        Script = "<script language=""javascript""> self.close(); </script>"
        'Script = Script + "parent.close();"
        Return Script
    End Function
    Enum Events
        LoginOk = 1
        LoginFailed = 2
    End Enum
    Public Shared Function GetConnectionString(Optional ByVal dbname As String = "amlak") As String
        Return "server=.;user id=sa;password=4Sardar;initial catalog=" + dbname
    End Function
    Public Shared Sub MyMsgBox(ByVal HTMLstr As String, Optional title As String = "", Optional second As Integer = 0, Optional redirect As String = "")
        Dim page As Page = HttpContext.Current.CurrentHandler
        If second <> 0 Then
            page.Master.FindControl("imgBtnClose").Visible = False
        Else
            page.Master.FindControl("imgBtnClose").Visible = True

        End If
        page.Master.FindControl("MsgBoxAll").Visible = True
        Dim span
        span = page.Master.FindControl("spnMessage")
        span.InnerHtml = HTMLstr
        span = page.Master.FindControl("spnTitle")
        span.InnerHtml = title

        If second <> 0 Then
            If redirect <> "" Then
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), "myAlertScript", "setTimeout(""window.location = '" + redirect + "';"", " + (second * 1000).ToString + ");", True)
            End If
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "myAlertScript", "setTimeout(""hide()"", " + (second * 1000).ToString + ");", True)
        End If

    End Sub

    Public Shared Sub SetError(ByVal HTMLstr As String)

        Dim page As Page = HttpContext.Current.CurrentHandler
        page.Master.FindControl("lblError").Visible = True
        Dim span
        span = page.Master.FindControl("lblError")
        span.text = HTMLstr

    End Sub
End Class