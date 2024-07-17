import {Component, OnInit} from '@angular/core';
import {CustomToastrService} from "../../Services/ui/custom-toastr.service";
import {Settings} from "../../Models/Settings";
import {GeneralSettingsService} from "../../Services/ui/Components/general-settings.service";

@Component({
  selector: 'app-general-settings',
  templateUrl: './general-settings.component.html',
  styleUrls: ['./general-settings.component.scss']
})
export class GeneralSettingsComponent implements OnInit {
  SettingsDialog: boolean = false;
  settings : Settings[] | undefined;
  mySettings: Settings = {};
  submitted: boolean = false;
  cols: any[] = [];

constructor(private toastrService: CustomToastrService,
            private settingsService: GeneralSettingsService) {}
  ngOnInit(){
    this.settingsService.getAllSettings().then(data => this.mySettings = data[0]);
  }
  async editSettings(mySettings: Settings) {
    this.mySettings = { ...mySettings };
    this.SettingsDialog = true;
  }
  hideDialog() {
    this.SettingsDialog = false;
    this.submitted = false;
  }
  async saveHoliday() {
    this.submitted = true;
    if (this.mySettings.settingsGuidId &&
      this.mySettings.dayHour &&
      this.mySettings.montHour &&
      this.mySettings.weekHour) {
      await this.settingsService.UpdateSettings(this.mySettings);
    }

    await this.settingsService.getAllSettings().then(data => this.settings = data);
    this.SettingsDialog = false;
    if (this.settings)
      this.mySettings = this.settings[0];
  }
}
