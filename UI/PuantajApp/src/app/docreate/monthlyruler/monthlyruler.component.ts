import {Component, OnInit} from '@angular/core';
import * as pdfMake from 'pdfmake/build/pdfmake.js';
import * as pdfFonts from 'pdfmake/build/vfs_fonts.js';
// @ts-ignore
pdfMake.vfs = pdfFonts.pdfMake.vfs;
@Component({
  selector: 'app-monthlyruler',
  templateUrl: './monthlyruler.component.html',
  styleUrls: ['./monthlyruler.component.scss']
})
export class MonthlyrulerComponent implements OnInit {
  ngOnInit(): void {}
  public export(): void {
    var docDefinition ={
      pageOrientation: 'landscape',
      content: [

        {
          table: {
            widths: [
              'auto', 85, 65, 'auto', 'auto',
              'auto', 'auto', 'auto', 'auto', 'auto',
              'auto', 'auto', 'auto', 'auto', 'auto',
              'auto', 'auto', 'auto', 'auto', 'auto',
              'auto', 'auto', 'auto', 'auto', 'auto',
              'auto', 'auto', 'auto', 'auto', 'auto',
              'auto', 'auto', 'auto', 'auto', 'auto',
              'auto',
            ],
            heights: [
              'auto', 'auto',
              'auto', 'auto', 'auto',
              'auto', 'auto', 'auto', 'auto', 'auto',
              'auto', 'auto', 'auto', 'auto', 'auto',
              'auto', 'auto', 'auto', 'auto'
            ],

            //headerRows: 2,
            // keepWithHeaderRows: 1,
            body: [
              [  //1
                {text: 'pHOTO', style: 'header', colSpan:2, rowSpan:5, alignment: 'center'},
                {},
                {text: '\n\nKISMI ZAMANLI ÖĞRENCİ', style: 'bheader',colSpan:30, rowSpan:3, alignment: 'center'},
                {},
                {},//5
                {},
                {},
                {},
                {},
                {},//10
                {},
                {},
                {},
                {},
                {},//15
                {},
                {},
                {},
                {},
                {},//20
                {},
                {},
                {},
                {},
                {},//25
                {},
                {},
                {},
                {},
                {},//30
                {},
                {},
                {text: 'Doküman No:', style: 'texter',colSpan:3, alignment: 'left'},
                {},
                {},//35
                {text: 'SKS.FR.0036', style: 'texter', alignment: 'center'},
              ],
              [  //2
                {},
                {},
                {},
                {},
                {},//5
                {},
                {},
                {},
                {},
                {},//10
                {},
                {},
                {},
                {},
                {},//15
                {},
                {},
                {},
                {},
                {},//20
                {},
                {},
                {},
                {},
                {},//25
                {},
                {},
                {},
                {},
                {},//30
                {},
                {},
                {text: 'Yayın Tarihi:', style: 'texter',colSpan:3, alignment: 'left'},
                {},
                {},//35
                {},
              ],
              [  //3
                {},
                {},
                {},
                {},
                {},//5
                {},
                {},
                {},
                {},
                {},//10
                {},
                {},
                {},
                {},
                {},//15
                {},
                {},
                {},
                {},
                {},//20
                {},
                {},
                {},
                {},
                {},//25
                {},
                {},
                {},
                {},
                {},//30
                {},
                {},
                {text: 'Revizyon Tarihi:', style: 'texter',colSpan:3, alignment: 'left'},
                {},
                {},//35
                {},
              ],
              [  //4
                {},
                {},
                {text: '\nAYLIK  PUANTAJ CETVELİ', style: 'bheader',colSpan:30, rowSpan:2, alignment: 'center'},
                {},
                {},//5
                {},
                {},
                {},
                {},
                {},//10
                {},
                {},
                {},
                {},
                {},//15
                {},
                {},
                {},
                {},
                {},//20
                {},
                {},
                {},
                {},
                {},//25
                {},
                {},
                {},
                {},
                {},//30
                {},
                {},
                {text: 'Revizyon No:', style: 'texter',colSpan:3, alignment: 'left'},
                {},
                {},//35
                {},
              ],
              [  //5
                {},
                {},
                {},
                {},
                {},//5
                {},
                {},
                {},
                {},
                {},//10
                {},
                {},
                {},
                {},
                {},//15
                {},
                {},
                {},
                {},
                {},//20
                {},
                {},
                {},
                {},
                {},//25
                {},
                {},
                {},
                {},
                {},//30
                {},
                {},
                {text: 'Sayfa:', style: 'texter',colSpan:3, alignment: 'left'},
                {},
                {},//35
                {},
              ],
              [  //6
                {},
                {},
                {},
                {},
                {},//5
                {},
                {},
                {},
                {},
                {},//10
                {},
                {},
                {},
                {},
                {},//15
                {},
                {},
                {},
                {},
                {},//20
                {},
                {},
                {},
                {},
                {},//25
                {},
                {text: 'AİT OLDUĞU AY', style: 'header2',colSpan:10, alignment: 'center'},
                {},
                {},
                {},//30
                {},
                {},
                {},
                {},
                {},//35
                {},
              ],
              [  //7
                {text: 'Sıra No', style: 'header2', alignment: 'center'},
                {text: 'ADI SOYADI', style: 'header2', alignment: 'center'},
                {text: 'GÖREV YERİ', style: 'header2', alignment: 'center'},
                {text: '1', style: 'header2', alignment: 'center'},
                {text: '2', style: 'header2', alignment: 'center'},//5
                {text: '3', style: 'header2', alignment: 'center'},
                {text: '4', style: 'header2', alignment: 'center'},
                {text: '5', style: 'header2', alignment: 'center'},
                {text: '6', style: 'header2', alignment: 'center'},
                {text: '7', style: 'header2', alignment: 'center'},//10
                {text: '8', style: 'header2', alignment: 'center'},
                {text: '9', style: 'header2', alignment: 'center'},
                {text: '10', style: 'header2', alignment: 'center'},
                {text: '11', style: 'header2', alignment: 'center'},
                {text: '12', style: 'header2', alignment: 'center'},//15
                {text: '13', style: 'header2', alignment: 'center'},
                {text: '14', style: 'header2', alignment: 'center'},
                {text: '15', style: 'header2', alignment: 'center'},
                {text: '16', style: 'header2', alignment: 'center'},
                {text: '17', style: 'header2', alignment: 'center'},//20
                {text: '18', style: 'header2', alignment: 'center'},
                {text: '19', style: 'header2', alignment: 'center'},
                {text: '20', style: 'header2', alignment: 'center'},
                {text: '21', style: 'header2', alignment: 'center'},
                {text: '22', style: 'header2', alignment: 'center'},//25
                {text: '23', style: 'header2', alignment: 'center'},
                {text: '24', style: 'header2', alignment: 'center'},
                {text: '25', style: 'header2', alignment: 'center'},
                {text: '26', style: 'header2', alignment: 'center'},
                {text: '27', style: 'header2', alignment: 'center'},//30
                {text: '28', style: 'header2', alignment: 'center'},
                {text: '29', style: 'header2', alignment: 'center'},
                {text: '30', style: 'header2', alignment: 'center'},
                {text: '31', style: 'header2', alignment: 'center'},
                {text: 'Çalışma Saati', style: 'header2', alignment: 'center'},//35
                {text: 'Ücreti', style: 'header2', alignment: 'center'},
              ],
              [  //8
                {text: '1', style: 'textleft', alignment: 'center'},
                {},
                {},
                {},
                {},//5
                {},
                {},
                {},
                {},
                {},//10
                {},
                {},
                {},
                {},
                {},//15
                {},
                {},
                {},
                {},
                {},//20
                {},
                {},
                {},
                {},
                {},//25
                {},
                {},
                {},
                {},
                {},//30
                {},
                {},
                {},
                {},
                {},//35
                {},
              ],
              [  //9
                {text: '2', style: 'textleft', alignment: 'center'},
                {},
                {},
                {},
                {},//5
                {},
                {},
                {},
                {},
                {},//10
                {},
                {},
                {},
                {},
                {},//15
                {},
                {},
                {},
                {},
                {},//20
                {},
                {},
                {},
                {},
                {},//25
                {},
                {},
                {},
                {},
                {},//30
                {},
                {},
                {},
                {},
                {},//35
                {},
              ],
              [  //10
                {text: '3', style: 'textleft', alignment: 'center'},
                {},
                {},
                {},
                {},//5
                {},
                {},
                {},
                {},
                {},//10
                {},
                {},
                {},
                {},
                {},//15
                {},
                {},
                {},
                {},
                {},//20
                {},
                {},
                {},
                {},
                {},//25
                {},
                {},
                {},
                {},
                {},//30
                {},
                {},
                {},
                {},
                {},//35
                {},
              ],
              [  //11
                {text: '4', style: 'textleft', alignment: 'center'},
                {},
                {},
                {},
                {},//5
                {},
                {},
                {},
                {},
                {},//10
                {},
                {},
                {},
                {},
                {},//15
                {},
                {},
                {},
                {},
                {},//20
                {},
                {},
                {},
                {},
                {},//25
                {},
                {},
                {},
                {},
                {},//30
                {},
                {},
                {},
                {},
                {},//35
                {},
              ],
              [  //12
                {text: '5', style: 'textleft', alignment: 'center'},
                {},
                {},
                {},
                {},//5
                {},
                {},
                {},
                {},
                {},//10
                {},
                {},
                {},
                {},
                {},//15
                {},
                {},
                {},
                {},
                {},//20
                {},
                {},
                {},
                {},
                {},//25
                {},
                {},
                {},
                {},
                {},//30
                {},
                {},
                {},
                {},
                {},//35
                {},
              ],
              [  //13
                {text: '6', style: 'textleft', alignment: 'center'},
                {},
                {},
                {},
                {},//5
                {},
                {},
                {},
                {},
                {},//10
                {},
                {},
                {},
                {},
                {},//15
                {},
                {},
                {},
                {},
                {},//20
                {},
                {},
                {},
                {},
                {},//25
                {},
                {},
                {},
                {},
                {},//30
                {},
                {},
                {},
                {},
                {},//35
                {},
              ],
              [  //14
                {text: '7', style: 'textleft', alignment: 'center'},
                {},
                {},
                {},
                {},//5
                {},
                {},
                {},
                {},
                {},//10
                {},
                {},
                {},
                {},
                {},//15
                {},
                {},
                {},
                {},
                {},//20
                {},
                {},
                {},
                {},
                {},//25
                {},
                {},
                {},
                {},
                {},//30
                {},
                {},
                {},
                {},
                {},//35
                {},
              ],
              [  //15
                {text: '8', style: 'textleft', alignment: 'center'},
                {},
                {},
                {},
                {},//5
                {},
                {},
                {},
                {},
                {},//10
                {},
                {},
                {},
                {},
                {},//15
                {},
                {},
                {},
                {},
                {},//20
                {},
                {},
                {},
                {},
                {},//25
                {},
                {},
                {},
                {},
                {},//30
                {},
                {},
                {},
                {},
                {},//35
                {},
              ],
              [  //16
                {text: '9', style: 'textleft', alignment: 'center'},
                {},
                {},
                {},
                {},//5
                {},
                {},
                {},
                {},
                {},//10
                {},
                {},
                {},
                {},
                {},//15
                {},
                {},
                {},
                {},
                {},//20
                {},
                {},
                {},
                {},
                {},//25
                {},
                {},
                {},
                {},
                {},//30
                {},
                {},
                {},
                {},
                {},//35
                {},
              ],
              [  //17
                {text: '', style: 'header2', colSpan:3, alignment: 'center'},
                {},
                {},
                {text: 'ADI VE SOYADI', style: 'header2', colSpan:17, alignment: 'center'},
                {},//5
                {},
                {},
                {},
                {},
                {},//10
                {},
                {},
                {},
                {},
                {},//15
                {},
                {},
                {},
                {},
                {},//20
                {text: 'ÜNVANI', style: 'header2', colSpan:10, alignment: 'center'},
                {},
                {},
                {},
                {},//25
                {},
                {},
                {},
                {},
                {},//30
                {text: 'İMZASI', style: 'header2', colSpan:6, alignment: 'center'},
                {},
                {},
                {},
                {},//35
                {},
              ],
              [  //18
                {text: 'DÜZENLEYEN', style: 'header2', colSpan:3, alignment: 'center'},
                {},
                {},
                {text: '', style: 'header2', colSpan:17, alignment: 'center'},
                {},//5
                {},
                {},
                {},
                {},
                {},//10
                {},
                {},
                {},
                {},
                {},//15
                {},
                {},
                {},
                {},
                {},//20
                {text: '', style: 'header2', colSpan:10, alignment: 'center'},
                {},
                {},
                {},
                {},//25
                {},
                {},
                {},
                {},
                {},//30
                {text: '', style: 'header2', colSpan:6, alignment: 'center'},
                {},
                {},
                {},
                {},//35
                {},
              ],
              [  //19
                {text: 'TASDİK EDEN', style: 'header2', colSpan:3, alignment: 'center'},
                {},
                {},
                {text: '', style: 'header2', colSpan:17, alignment: 'center'},
                {},//5
                {},
                {},
                {},
                {},
                {},//10
                {},
                {},
                {},
                {},
                {},//15
                {},
                {},
                {},
                {},
                {},//20
                {text: '', style: 'header2', colSpan:10, alignment: 'center'},
                {},
                {},
                {},
                {},//25
                {},
                {},
                {},
                {},
                {},//30
                {text: '', style: 'header2', colSpan:6, alignment: 'center'},
                {},
                {},
                {},
                {},//35
                {},
              ],
            ]
          }
        },

      ],
      styles: {
        bheader: {
          fontSize: 12,
          bold: true
        },
        header: {
          fontSize: 8,
          bold: true
        },
        header2: {
          fontSize: 7,
          bold: true,

        },
        header3: {
          fontSize: 7,
          bold: true,

        },
        texter:{
          fontSize: 7,
          bold: false
        },
        textleft:{
          fontSize: 5,
          bold: true
        },
        tableblack:{
          background: 'black'
        }

      }

    }
    // @ts-ignore
    pdfMake.createPdf(docDefinition).download("test.pdf");
  }

}
