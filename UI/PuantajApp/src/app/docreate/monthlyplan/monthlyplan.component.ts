import {Component, Input, OnInit} from '@angular/core';
import * as pdfMake from 'pdfmake/build/pdfmake.js';
import * as pdfFonts from 'pdfmake/build/vfs_fonts.js';
import {StudentService} from "../../Services/ui/Components/student.service";
import {Student} from "../../Models/student";
import {JobUnit} from "../../Models/job-unit";
import {JobUnitService} from "../../Services/ui/Components/job-unit.service";
import {JobDepartmentService} from "../../Services/ui/Components/job-department.service";
import {JobDepartment} from "../../Models/JobDepartment";
import {delay} from "rxjs";
import {toNumbers} from "@angular/compiler-cli/src/version_helpers";

// @ts-ignore
pdfMake.vfs = pdfFonts.pdfMake.vfs;

@Component({
  selector: 'app-monthlyplan',
  templateUrl: './monthlyplan.component.html',
  styleUrls: ['./monthlyplan.component.scss']
})
export class MonthlyplanComponent implements OnInit {
  constructor(private studentService: StudentService,
              private jobUnitService: JobUnitService,
              private jobDepartmentService: JobDepartmentService) {
  }
  @Input() receivedData!: any;
  @Input() studentId!: any;
  mystudent: Student = {};
  selectedJobUnit?: JobUnit;
  selectedDepartment?: JobDepartment;
  Year?: number;
  Month?: number;
  MyMonths: any[] = [];


  ngOnInit(): void {
    this.myGetStudent();

    this.MyMonths = [
      { label: 'Ocak', value: 0 },
      { label: 'Şubat', value: 1 },
      { label: 'Mart', value: 2 },
      { label: 'Nisan', value: 3 },
      { label: 'Mayıs', value: 4 },
      { label: 'Haziran', value: 5 },
      { label: 'Temmuz', value: 6 },
      { label: 'Ağustos', value: 7 },
      { label: 'Eylül', value: 8 },
      { label: 'Ekim', value: 9 },
      { label: 'Kasım', value: 10 },
      { label: 'Aralık', value: 11 },
    ];
  }
  myGetStudent(){
    return new Promise<void>((resolve, reject) => {
      this.studentService.getStudentById(this.studentId).then(data => {
        this.mystudent = data
        this.myGetJobUnit(data.jobUnitGuidId);
      });
      resolve();
    });
  }
  myGetJobUnit(JobID: string){
    return new Promise<void>((resolve, reject) => {
      this.jobUnitService.getJobUnitById(JobID).then(data => {
        this.selectedJobUnit = data
        this.myGetJobDepartmant(data.jobDepartmentGuidId);
      });
      resolve();
    });
  }
  myGetJobDepartmant(DepID: string){
    return new Promise<void>((resolve, reject) => {
      this.jobDepartmentService.getJobDepartmentById(DepID!).then(data => this.selectedDepartment = data);
      resolve();
    });
  }
  getMonth(date:Date){
    let myDate = new Date(date);
    let myMonth = myDate.getMonth();
    let filMo = this.MyMonths.find(month => month.value === myMonth);
    this.Month = filMo.label;
  }
  getYear(date:Date){
    let myDate = new Date(date);
    let myYear = myDate.getFullYear();
    this.Year = myYear;
  }
  getHour(date: Date){
    let myDate = new Date(date);
    let myHour = myDate.getHours().toString().padStart(2, '0');
    let myMinute = myDate.getMinutes().toString().padStart(2, '0');
    return  myHour + ":" + myMinute;
  }
  getWeekNumberAndDay(date: Date) {
    let thdate = new Date(date);
    let startDate = new Date(thdate.getFullYear(), thdate.getMonth(), 1);
    // @ts-ignore
    let days = Math.floor((thdate - startDate) / (24 * 60 * 60 * 1000));
    let weekNumber = Math.ceil((days + startDate.getDay()) / 7);
    let dayOfWeek = (thdate.getDay() + 6) % 7;

    return weekNumber.toString() + dayOfWeek.toString();
  }

  public test(): void{
    console.log(this.getHour(this.receivedData[0].firstDate));
    console.log(this.getWeekNumberAndDay(this.receivedData[0].firstDate));
    console.log(this.receivedData);
  }
  public export(): void {
    var docDefinition = {
      pageOrientation: 'landscape',
      content: [
        {
          text: 'GAZİ ÜNİVERSİTESİ',
          style: 'header',
          alignment: 'center'
        },
        {
          text: 'SAĞLIK KÜLTÜR VE SPOR DAİRE BAŞKANLIĞI',
          style: 'header',
          alignment: 'center'
        },
        {
          text: 'ÖĞRENCİ DANIŞMA VE BURS HİZMETLERİ BİRİMİ',
          style: 'header',
          alignment: 'center'
        },
        {
          text: this.Year! +' '+ this.Month! + ' AYI KISMİ ZAMANLI ÖĞRENCİ AYLIK ÇALIŞMA PLANI',
          style: 'header',
          alignment: 'center'
        },
        {
          columns: [
            {
              width: 130,
              text: 'Öğrencinin Adı Soyadı'
            },
            {
              width: 15,
              text: ':'
            },
            {
              width: '*',
              text: this.mystudent.nameSurname
            },
          ]
        },
        {
          columns: [
            {
              width: 130,
              text: 'Öğrenci No'
            },
            {
              width: 15,
              text: ':'
            },
            {
              width: '*',
              text: this.mystudent.studentNo
            },
          ]
        },
        {
          columns: [
            {
              width: 130,
              text: 'Çalışılan Birim'
            },
            {
              width: 15,
              text: ':'
            },
            {
              width: '*',
              text: this.selectedDepartment?.name
            },
          ]
        },
        {
          columns: [
            {
              width: 130,
              text: 'Görev Tanımı\n\n'
            },
            {
              width: 15,
              text: ':'
            },
            {
              width: '*',
              text: this.selectedJobUnit?.jobUnitName
            },
          ]
        },
        {
          style: 'tableExample',
          table: {
            widths: [70,90,90,90,90,90,90,90],
            body: [
              [
                {text: 'HAFTA', style: 'tableText'},
                {text: 'PAZARTESİ', style: 'tableText'},
                {text: 'SALI', style: 'tableText'},
                {text: 'ÇARŞAMBA',style: 'tableText'},
                {text: 'PERŞEMBE', style: 'tableText'},
                {text: 'CUMA', style: 'tableText'},
                {text: 'CUMARTESİ', style: 'tableText'},
                {text: 'PAZAR', style: 'tableText'},
              ],
              [
                {rowSpan: 2 , text: '1. HAFTA', style: 'tableText', margin: [0, 12]},
                {text: ' ', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
              ],
              [
                { text: ''},
                {text: ' ', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
              ],
              [
                {rowSpan: 2 , text: '2. HAFTA', style: 'tableText', margin: [0, 12]},
                {text: ' ', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
              ],
              [
                { text: ''},
                {text: ' ', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
              ],
              [
                {rowSpan: 2 , text: '3. HAFTA', style: 'tableText', margin: [0, 12]},
                {text: ' ', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
              ],
              [
                { text: ''},
                {text: ' ', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
              ],
              [
                {rowSpan: 2 , text: '4. HAFTA', style: 'tableText', margin: [0, 12]},
                {text: ' ', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
              ],
              [
                { text: ''},
                {text: ' ', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
              ],
              [
                {rowSpan: 2 , text: '5. HAFTA', style: 'tableText', margin: [0, 12]},
                {text: ' ', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
              ],
              [
                { text: ''},
                {text: ' ', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
                {text: '', alignment: 'center'},
              ],


            ],

          }
        },
        {
          text: '\nMADDE 11- (1) Kısmi zamanlı öğrenciler, belirlenen iş saatlerinde işinin başında olmakla yükümlüdür ve iş saatleri bitmeden izinsiz olarak işyerinden ayrılamazlar.',
          style: 'small'
        },
        {
          text: 'MADDE 12- (1) Kısmi zamanlı öğrenciler, çalıştığı birimin itibarını ve saygınlığını veya görev haysiyetini zedeleyici fiil ve davranışlarda bulunamaz.',
          style: 'small'
        },
        {
          text: '(2) Kısmi zamanlı öğrenciler, amirleriyle ve çalışma arkadaşlarıyla olan ilişkilerde saygılı olmak, işlerini tarafsızlıkla, tam ve zamanında yapmakla yükümlüdür.',
          style: 'small'
        },
        {
          text: '(3) Kısmi zamanlı öğrenciler, kendilerine verilen görevleri ilgili mevzuat esasları ve amirleri tarafından verilen talimatlar doğrultusunda yerine getirmekle yükümlü ve sorumludur.',
          style: 'small'
        },
        {
          text: '(4) Kısmi zamanlı öğrenciler, işyerinde belirlenmiş bulunan çalışma şartlarına, iş disiplinine, iş sağlığı ve güvenliği kurallarına, yönetmelik, genelge, talimat gibi düzenlemelere uymak zorundadır.',
          style: 'small'
        },
        {
          text: '(5) Kısmi zamanlı öğrenciler işlerini dikkat ve itina ile yerine getirmek ve kendilerine teslim edilen Devlet malını korumak ve her an hizmete hazır halde bulundurmak zorundadır.\n\n',
          style: 'small'
        },
        {
          columns: [
            {
              width: 200,
              text: 'ÖĞRENCİ',
              alignment: 'center'
            },
            {
              width: '*',
              text: '',
              alignment: 'center'
            },
            {
              width: 250,
              text: 'BİRİM YÖNETİCİSİ',
              alignment: 'center'
            },

          ],
          style: 'small'
        },
        {
          columns: [
            {
              width: 200,
              text: '(Adı Soyadı - İmza)',
              alignment: 'center'
            },
            {
              width: '*',
              text: '',
              alignment: 'center'
            },
            {
              width: 250,
              text: '(Adı Soyadı - İmza)',
              alignment: 'center'
            },
          ],
          style: 'small'
        },
      ],

      styles: {
        header: {
          fontSize: 11,
          bold: true,
          alignment: 'justify'
        },
        small: {
          fontSize: 8
        },
        tableText: {
          fontSize: 11,
          bold: true,
          alignment: 'center',


        },
      }
    };

    // @ts-ignore
    pdfMake.createPdf(docDefinition).download("test.pdf");
  }
}
