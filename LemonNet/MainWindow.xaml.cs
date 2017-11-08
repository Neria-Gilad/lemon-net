﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;

namespace LemonNet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isVirus;
        private RegistryKey key1;
        private RegistryKey key2;
    

        #region Registry in HEX
        private string data1 = "0f,00,00,00,01,00,00,00,14,00,00,00,96,6a,34,ac,18,de,9c,52,94,b2," +
                               "8c,6c,d4,c3,37,56,5b,3d,4b,b0,14,00,00,00,01,00,00,00,14,00,00,00,40,01,64," +
                               "41,34,3c,ed,93,b9,6f,ea,49,65,33,3a,f9,05,cc,05,e4,03,00,00,00,01,00,00,00," +
                               "14,00,00,00,db,22,ed,c8,fc,cd,f8,45,b2,96,00,94,7f,46,6e,e8,52,5c,6d,42,04," +
                               "00,00,00,01,00,00,00,10,00,00,00,1b,bf,66,c0,8b,e0,6c,e7,3a,3e,aa,6e,b4,90," +
                               "2b,7b,19,00,00,00,01,00,00,00,10,00,00,00,2f,3a,db,60,1e,4d,e2,f3,0e,cb,bb," +
                               "7b,4e,56,e7,86,20,00,00,00,01,00,00,00,de,03,00,00,30,82,03,da,30,82,03,43," +
                               "a0,03,02,01,02,02,09,00,99,15,0f,0d,3d,e1,a1,d3,30,0d,06,09,2a,86,48,86,f7," +
                               "0d,01,01,05,05,00,30,81,a5,31,0b,30,09,06,03,55,04,06,13,02,55,53,31,11,30," +
                               "0f,06,03,55,04,08,13,08,4e,65,77,20,59,6f,72,6b,31,11,30,0f,06,03,55,04,07," +
                               "13,08,4e,65,77,20,59,6f,72,6b,31,11,30,0f,06,03,55,04,0a,13,08,4e,65,74,53," +
                               "70,61,72,6b,31,1d,30,1b,06,03,55,04,0b,13,14,4e,65,74,53,70,61,72,6b,20,44," +
                               "65,76,65,6c,6f,70,6d,65,6e,74,31,19,30,17,06,03,55,04,03,13,10,77,77,77,2e," +
                               "6e,65,74,73,70,61,72,6b,2e,63,6f,6d,31,23,30,21,06,09,2a,86,48,86,f7,0d,01," +
                               "09,01,16,14,73,75,70,70,6f,72,74,40,6e,65,74,73,70,61,72,6b,2e,63,6f,6d,30," +
                               "1e,17,0d,31,32,30,33,32,31,31,32,31,39,30,33,5a,17,0d,33,31,30,35,32,31,31," +
                               "32,31,39,30,33,5a,30,81,a5,31,0b,30,09,06,03,55,04,06,13,02,55,53,31,11,30," +
                               "0f,06,03,55,04,08,13,08,4e,65,77,20,59,6f,72,6b,31,11,30,0f,06,03,55,04,07," +
                               "13,08,4e,65,77,20,59,6f,72,6b,31,11,30,0f,06,03,55,04,0a,13,08,4e,65,74,53," +
                               "70,61,72,6b,31,1d,30,1b,06,03,55,04,0b,13,14,4e,65,74,53,70,61,72,6b,20,44," +
                               "65,76,65,6c,6f,70,6d,65,6e,74,31,19,30,17,06,03,55,04,03,13,10,77,77,77,2e," +
                               "6e,65,74,73,70,61,72,6b,2e,63,6f,6d,31,23,30,21,06,09,2a,86,48,86,f7,0d,01," +
                               "09,01,16,14,73,75,70,70,6f,72,74,40,6e,65,74,73,70,61,72,6b,2e,63,6f,6d,30," +
                               "81,9f,30,0d,06,09,2a,86,48,86,f7,0d,01,01,01,05,00,03,81,8d,00,30,81,89,02," +
                               "81,81,00,cf,1b,f8,0a,67,af,3e,b7,5c,df,8a,8d,cb,cd,b6,64,16,fb,4a,83,ed,09," +
                               "a2,76,1f,1c,b6,89,02,0d,47,ea,24,83,eb,79,22,52,8a,77,1d,2b,e7,da,9d,d5,3f," +
                               "7c,21,d8,22,4d,c3,6c,41,8b,3e,ca,04,8b,0b,82,e8,23,1a,c0,01,5c,4a,3b,49,a6," +
                               "33,c1,5d,c9,fa,ff,bd,dd,21,e5,37,16,47,93,af,18,2b,1c,ca,c6,9b,76,9a,20,6c," +
                               "27,72,19,6d,5b,e8,8e,0e,9a,da,8a,d9,99,21,0e,30,25,dd,c2,f2,9c,3c,d9,4c,b1," +
                               "a4,c0,89,58,09,63,02,03,01,00,01,a3,82,01,0e,30,82,01,0a,30,1d,06,03,55,1d," +
                               "0e,04,16,04,14,40,01,64,41,34,3c,ed,93,b9,6f,ea,49,65,33,3a,f9,05,cc,05,e4," +
                               "30,81,da,06,03,55,1d,23,04,81,d2,30,81,cf,80,14,40,01,64,41,34,3c,ed,93,b9," +
                               "6f,ea,49,65,33,3a,f9,05,cc,05,e4,a1,81,ab,a4,81,a8,30,81,a5,31,0b,30,09,06," +
                               "03,55,04,06,13,02,55,53,31,11,30,0f,06,03,55,04,08,13,08,4e,65,77,20,59,6f," +
                               "72,6b,31,11,30,0f,06,03,55,04,07,13,08,4e,65,77,20,59,6f,72,6b,31,11,30,0f," +
                               "06,03,55,04,0a,13,08,4e,65,74,53,70,61,72,6b,31,1d,30,1b,06,03,55,04,0b,13," +
                               "14,4e,65,74,53,70,61,72,6b,20,44,65,76,65,6c,6f,70,6d,65,6e,74,31,19,30,17," +
                               "06,03,55,04,03,13,10,77,77,77,2e,6e,65,74,73,70,61,72,6b,2e,63,6f,6d,31,23," +
                               "30,21,06,09,2a,86,48,86,f7,0d,01,09,01,16,14,73,75,70,70,6f,72,74,40,6e,65," +
                               "74,73,70,61,72,6b,2e,63,6f,6d,82,09,00,99,15,0f,0d,3d,e1,a1,d3,30,0c,06,03," +
                               "55,1d,13,04,05,30,03,01,01,ff,30,0d,06,09,2a,86,48,86,f7,0d,01,01,05,05,00," +
                               "03,81,81,00,47,4c,2b,c0,3b,b5,ba,33,b8,41,9d,ce,0e,92,98,8f,15,69,17,e2,45," +
                               "03,6e,94,ea,a6,4f,b4,c3,e1,d4,8b,3d,ee,93,26,43,d3,a9,f2,5d,db,b4,d7,6b,ed," +
                               "bd,ce,a6,e2,b6,88,26,ae,3d,b8,2e,0a,9d,a0,32,74,25,6e,7d,02,7a,c3,0d,98,d9," +
                               "ab,2b,7f,05,6c,00,68,7f,98,74,fb,e6,c2,84,de,08,a1,8f,54,f8,17,4a,2a,2d,98," +
                               "19,a9,f7,e2,07,a6,bb,c5,3f,11,80,df,ba,67,39,0c,1f,7f,d9,66,e0,a1,6f,4d,1b," +
                               "e2,0a,37,55,96,8a,7a";

        private string data2 = "5c,00,00,00,01,00,00,00,04,00,00,00,00,10,00,00,03,00,00,00,01,00," +
                               "00,00,14,00,00,00,1e,cf,5f,f1,ec,b6,6b,61,1f,7e,ca,da,b6,ea,97,9c,02,e2,24," +
                               "c6,19,00,00,00,01,00,00,00,10,00,00,00,ff,51,94,49,d6,88,5a,4d,38,06,1f,ea," +
                               "3c,74,93,90,14,00,00,00,01,00,00,00,14,00,00,00,1d,9d,c6,15,93,95,b0,46,02," +
                               "96,43,56,c0,c6,22,7d,c5,03,2f,a5,0f,00,00,00,01,00,00,00,40,00,00,00,67,f5," +
                               "43,fe,b9,90,51,6d,76,ae,02,f9,3a,10,07,e0,ba,34,9d,9f,cb,55,fd,4d,9b,37,49," +
                               "14,f1,e8,98,b0,4d,39,5c,9d,a5,c9,6b,69,0a,62,1b,d7,49,fb,6a,0a,13,26,a9,16," +
                               "4b,8b,18,88,76,ea,30,50,4e,68,ea,31,04,00,00,00,01,00,00,00,10,00,00,00,a6," +
                               "c6,24,d7,4d,fd,ba,11,44,cb,62,2a,4d,7f,3e,7c,20,00,00,00,01,00,00,00,5e,06," +
                               "00,00,30,82,06,5a,30,82,04,42,a0,03,02,01,02,02,09,00,b7,48,43,33,eb,b0,94," +
                               "c2,30,0d,06,09,2a,86,48,86,f7,0d,01,01,0d,05,00,30,81,9d,31,0b,30,09,06,03," +
                               "55,04,06,13,02,55,53,31,11,30,0f,06,03,55,04,08,0c,08,4e,65,77,20,59,6f,72," +
                               "6b,31,11,30,0f,06,03,55,04,07,0c,08,4e,65,77,20,59,6f,72,6b,31,11,30,0f,06," +
                               "03,55,04,0a,0c,08,4e,65,74,73,70,61,72,6b,31,15,30,13,06,03,55,04,0b,0c,0c," +
                               "4e,65,74,73,70,61,72,6b,20,52,49,4d,31,19,30,17,06,03,55,04,03,0c,10,77,77," +
                               "77,2e,6e,65,74,73,70,61,72,6b,2e,63,6f,6d,31,23,30,21,06,09,2a,86,48,86,f7," +
                               "0d,01,09,01,16,14,73,75,70,70,6f,72,74,40,6e,65,74,73,70,61,72,6b,2e,63,6f," +
                               "6d,30,1e,17,0d,31,36,30,37,31,34,31,34,30,36,35,30,5a,17,0d,33,36,30,37,30," +
                               "39,31,34,30,36,35,30,5a,30,81,9d,31,0b,30,09,06,03,55,04,06,13,02,55,53,31," +
                               "11,30,0f,06,03,55,04,08,0c,08,4e,65,77,20,59,6f,72,6b,31,11,30,0f,06,03,55," +
                               "04,07,0c,08,4e,65,77,20,59,6f,72,6b,31,11,30,0f,06,03,55,04,0a,0c,08,4e,65," +
                               "74,73,70,61,72,6b,31,15,30,13,06,03,55,04,0b,0c,0c,4e,65,74,73,70,61,72,6b," +
                               "20,52,49,4d,31,19,30,17,06,03,55,04,03,0c,10,77,77,77,2e,6e,65,74,73,70,61," +
                               "72,6b,2e,63,6f,6d,31,23,30,21,06,09,2a,86,48,86,f7,0d,01,09,01,16,14,73,75," +
                               "70,70,6f,72,74,40,6e,65,74,73,70,61,72,6b,2e,63,6f,6d,30,82,02,22,30,0d,06," +
                               "09,2a,86,48,86,f7,0d,01,01,01,05,00,03,82,02,0f,00,30,82,02,0a,02,82,02,01," +
                               "00,b8,59,89,1c,5a,5a,89,8a,a8,1c,3e,97,36,5d,cd,10,a7,e7,c6,16,7f,19,b1,cb," +
                               "7c,27,8c,70,1e,dd,46,12,72,f5,05,47,32,31,b7,b6,1f,ba,60,d7,80,e3,6f,8b,65," +
                               "97,3a,49,2f,bb,1d,72,40,8f,74,b8,16,89,cf,9f,ad,d4,4f,7d,d4,7f,0e,99,ed,58," +
                               "b9,4c,71,9d,7a,51,d9,dc,75,94,ac,b8,73,a2,46,c2,8b,2d,e3,d0,74,0f,45,dc,63," +
                               "05,e3,12,e6,b2,f0,94,5a,57,2e,9b,b3,b2,02,3d,29,52,8c,f9,ed,a4,8b,61,81,6d," +
                               "a2,04,b6,86,ad,06,01,48,dd,6d,7d,ab,f9,4e,eb,c9,10,42,2e,23,c3,b8,6f,fa,87," +
                               "88,43,84,bc,b8,32,4e,74,ae,b3,59,0a,85,73,ba,e3,c7,f4,94,cd,eb,6f,7c,58,9f," +
                               "7a,70,0d,c7,2d,52,69,65,a7,b8,f1,64,a6,fb,2a,86,96,75,ac,a2,c4,fb,d1,d7,f5," +
                               "c0,08,73,a4,fd,0c,f3,17,5c,db,ad,d2,ab,ca,f7,60,3e,5a,61,ac,68,20,d1,54,e8," +
                               "ba,c2,bb,e4,23,0f,5d,7f,c9,04,b6,21,0d,25,d9,b8,02,94,5d,d6,ec,c1,27,e7,43," +
                               "1e,c3,e6,8e,7a,17,4b,23,96,7b,0b,cc,e8,00,a6,ee,64,39,c3,a0,2c,d7,2f,88,cb," +
                               "46,c7,66,10,df,c6,39,4f,bc,0d,d1,05,c3,e7,6a,51,2b,c7,dc,00,c2,c7,a4,5b,43," +
                               "74,ef,47,f3,03,25,f9,5d,bf,5b,09,cd,be,62,9e,12,d0,c0,f2,09,cf,ee,33,e9,46," +
                               "ec,60,33,47,d0,ce,31,1b,4e,8e,d3,38,64,d5,d8,dd,a5,1c,97,7a,5e,0a,23,8d,5f," +
                               "f9,31,3a,1b,11,06,9e,12,6d,57,a3,f8,db,18,3b,61,8b,8d,00,de,32,da,15,7e,1e," +
                               "c6,88,40,07,bb,ac,15,e0,41,bb,ee,33,ab,30,54,07,83,5b,66,36,9d,f4,2a,42,59," +
                               "bc,34,b5,ff,45,d0,0c,23,41,0e,30,dc,8a,b9,9a,84,bc,3c,bc,57,08,ec,9c,43,23," +
                               "d0,89,1a,bd,4e,2b,d0,d7,bb,ea,9c,90,98,82,ca,03,8a,0e,62,3d,31,95,16,14,26," +
                               "83,6d,ca,cb,de,d5,64,b0,b2,e2,33,e5,dc,c1,cb,a6,12,cd,3e,a9,65,6a,b2,25,01," +
                               "47,84,44,a1,77,2e,f2,75,6e,fe,18,72,60,9a,c1,fb,b5,16,c8,ff,e8,20,bd,d9,65," +
                               "ef,67,7c,02,06,0c,48,89,6b,c7,f4,31,4f,02,03,01,00,01,a3,81,9a,30,81,97,30," +
                               "1d,06,03,55,1d,0e,04,16,04,14,1d,9d,c6,15,93,95,b0,46,02,96,43,56,c0,c6,22," +
                               "7d,c5,03,2f,a5,30,1f,06,03,55,1d,23,04,18,30,16,80,14,1d,9d,c6,15,93,95,b0," +
                               "46,02,96,43,56,c0,c6,22,7d,c5,03,2f,a5,30,0f,06,03,55,1d,13,01,01,ff,04,05," +
                               "30,03,01,01,ff,30,0e,06,03,55,1d,0f,01,01,ff,04,04,03,02,01,86,30,34,06,08," +
                               "2b,06,01,05,05,07,01,01,04,28,30,26,30,24,06,08,2b,06,01,05,05,07,30,01,86," +
                               "18,68,74,74,70,3a,2f,2f,6f,63,73,70,2e,6e,65,74,73,70,61,72,6b,2e,63,6f,6d," +
                               "30,0d,06,09,2a,86,48,86,f7,0d,01,01,0d,05,00,03,82,02,01,00,38,7e,fa,f6,de," +
                               "3f,98,6f,95,9c,3d,47,30,b7,e1,a5,7b,fe,18,3b,6a,92,31,71,4a,bf,bb,e6,e2,82," +
                               "cb,c0,92,89,57,8c,9a,43,b0,32,d6,45,0a,3e,76,f8,59,8f,ed,72,9a,b9,e4,d6,d5," +
                               "fe,61,02,60,ac,e3,ef,a0,51,87,52,8c,38,20,90,17,5f,ec,0f,e2,07,f0,f5,1b,0d," +
                               "85,3c,ab,9c,c0,83,40,89,2f,27,cd,82,b2,fb,c9,07,c7,ad,87,7d,b9,75,b3,9c,86," +
                               "dd,0e,f9,23,a8,2b,9f,b1,ec,c6,6e,30,f2,a5,35,56,62,df,0d,67,ab,93,6d,d3,17," +
                               "26,80,d0,87,0b,0d,29,9c,d7,74,5a,10,a6,32,9d,ff,05,db,a2,8f,8e,47,37,9d,f9," +
                               "a4,d7,36,ad,83,3c,f2,4a,4a,74,58,01,0a,dc,e2,a3,e6,16,84,c1,90,6d,07,97,73," +
                               "7c,38,19,bb,01,db,3a,4f,73,2f,4a,65,7c,6e,43,31,8b,cd,e1,4d,8a,ce,4a,50,a5," +
                               "da,bf,39,f5,1f,3d,34,91,28,e4,78,81,15,70,bc,1b,a5,82,e4,eb,51,04,d6,4b,c1," +
                               "01,c7,91,41,8d,98,bb,26,aa,c0,c0,be,9e,72,a2,c3,64,92,57,a3,94,08,0a,65,c1," +
                               "9b,73,5b,34,91,81,c6,cb,c4,bd,00,67,6e,2a,46,d6,d9,3c,97,48,e0,c6,83,be,09," +
                               "a9,2a,86,c9,11,d5,7e,8a,3e,47,c4,2d,06,7f,36,77,bf,93,c4,2e,a1,c8,e9,56,18," +
                               "dc,05,bd,28,b8,ff,f1,89,1c,1c,1e,06,3e,12,fc,a0,c9,9f,b9,42,63,d0,34,ab,c1," +
                               "cf,06,0b,59,44,44,f0,a2,cf,bb,2a,6d,70,ff,f6,b1,74,e5,b5,80,b0,33,98,2c,65," +
                               "3b,d9,7f,06,54,fb,a3,c6,04,c6,71,1b,0e,1f,79,ab,7e,e4,63,c3,8c,ec,53,7f,e4," +
                               "0f,98,bb,e6,54,f7,9a,bc,10,39,36,a0,d5,fb,9b,85,1f,8f,a7,65,af,19,12,49,58," +
                               "11,ca,9e,6d,a5,78,a4,8f,c5,ec,eb,7d,99,f2,1e,33,ac,5a,5b,8d,5a,28,e9,1d,18," +
                               "3b,a0,cb,31,b1,c6,6e,14,e7,c0,cb,eb,8f,c2,34,96,49,11,03,d6,e3,51,33,b6,14," +
                               "ea,40,0b,74,a0,87,ed,a3,cb,94,3d,ad,05,24,03,58,33,7c,87,80,1e,69,98,3b,03," +
                               "96,5b,c9,8c,36,88,68,3a,45,2f,cb,a5,1e,63,ab,de,36,68,12,37,8d,ae,fe,87,62," +
                               "aa,36,d9,93,71,43,91";
        #endregion
        #region STRINGS
        private string CertificatesPath = @"SOFTWARE\Microsoft\SystemCertificates\ROOT\Certificates\";
        private string CertTree1 = "DB22EDC8FCCDF845B29600947F466EE8525C6D42";
        private string CertTree2 = "1ECF5FF1ECB66B611F7ECADAB6EA979C02E224C6";
        private string SuccessTitle = "נראה שהצלחנו";
        private string SuccessMessage = "?להחלת השינויים יש לבצע הפעלה מחדש לכרום, לבצע";
        private string _longInfoText_unprotected = @"יבגני (שם בדוי) הוא בחור בן 36 העובד בשכר מינימום.
נגלה רק שהשם של מקום עבודתו נשמע כמו ''בטספארק''. 
תפקידו, כביכול, לשמור על קדושתך ע''י מעבר יסודי על היסטוריית הגלישה שלך.
זוכר שהתחברת למייל היום? גם יבגני זוכר!
קנית מגן לפלאפון הכשר? יבגני יודע!
התלבטת על סיסמה חדשה לחשבון הבנק? יבגני בחר בשבילך!
ליבגני יש את פרטי הבנק שלך... ולמבורגיני.
שכר מינימום לא קונה למבורגיני.

ברצינות, המלצתנו שלא תיכנס לאתרים המכילים מידע רגיש.
";

        private string _longInfoText_protected = @"המערכת זיהתה שכבודו מאצולת הVPN (או בעל חבילת גלישה אינסופית).
אין (עדיין) סינים שמשתמשים בזהות שלך כדי להתגנב לארץ
או בכרטיס שלך לקנות תאילנדיים באיביי (השקעה משתלמת).
כבודו זוכה לאינטרנט מהפכני ''5G'' המסוגל להגיע אף ל10Kbps!
כל הכבוד, you are the real MVP.
עכשיו אפשר להתחיל לחסוך ללמבורגיני
";

        private string _toggleButtonContent_unprotected= "לחץ לעבור למצב בטוח";
        private string _toggleButtonContent_protected = "לחץ לשימוש באינטרט";

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            RegistryKey key = Registry.LocalMachine.OpenSubKey(
                CertificatesPath + CertTree1, true);
            isVirus = (key != null);
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            if (isVirus)
            {
                LongInfoText.Text = _longInfoText_unprotected;
                ToggleButton.Content = _toggleButtonContent_unprotected;
                ShortInfoText.Text = "פומבי";
                ShortInfoText.Foreground = Brushes.Red;
            }
            else
            {
                LongInfoText.Text = _longInfoText_protected;
                ToggleButton.Content = _toggleButtonContent_protected;
                ShortInfoText.Text = "פרטי";
                ShortInfoText.Foreground = Brushes.LimeGreen;
            }
        }

        private void RestartChrome()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = @"/C taskkill /IM chrome.exe /F & start chrome.exe";
            process.StartInfo = startInfo;
            process.Start();
            
        }

        private void WriteReg()
        {
            key1 = Registry.LocalMachine.CreateSubKey(CertificatesPath + CertTree1, true);
            key2 = Registry.LocalMachine.CreateSubKey(CertificatesPath + CertTree2, true);

            key1.SetValue("Blob", data1.Split(',').Select(x => Convert.ToByte(x, 16)).ToArray(), RegistryValueKind.Binary);
            key2.SetValue("Blob", data2.Split(',').Select(x => Convert.ToByte(x, 16)).ToArray(), RegistryValueKind.Binary);
            key1.Close();
            key2.Close();
        }

        private void EraseReg()
        {
            key1 = Registry.LocalMachine.OpenSubKey(CertificatesPath, true);
            key2 = Registry.LocalMachine.OpenSubKey(CertificatesPath, true);

            key1.DeleteSubKeyTree(CertTree1);
            key2.DeleteSubKeyTree(CertTree2);

            key1.Close();
            key2.Close();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (isVirus) EraseReg();
            else WriteReg();

            isVirus = !isVirus;
            UpdateInfo();
            System.Diagnostics.Process[] chromeInstances = System.Diagnostics.Process.GetProcessesByName("chrome");
            if (chromeInstances.Length > 0)
            {
                var result = MessageBox.Show(SuccessMessage, SuccessTitle, MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes) RestartChrome();
            }
        }
    }
}
