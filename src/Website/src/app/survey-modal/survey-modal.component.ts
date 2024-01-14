import {
  Component, EventEmitter, Input,
  Output, ViewChild
} from "@angular/core";
import { NgSelectComponent } from "@ng-select/ng-select";
import { SessionService } from "../session/session.service";
import { Survey, SurveyItem, SurveyItemRatingType } from '../shared/services/api';

@Component({
  selector: "app-survey-modal",
  templateUrl: "./survey-modal.component.html",
  styleUrls: ["survey-modal.component.css"],
})
export class SurveyModalComponent {
  private _currentSurvey: Survey = {} as Survey;
  private _currentSurveyItem: SurveyItem = { } as SurveyItem;
  public surveyItemInputFormText = "";
  private _surveyItemRatingTypes!: string[];

  constructor(private sessionService: SessionService) {
    this.setSurveyItemRatingTypes();
  }

  @Output()
  public close = new EventEmitter();

  @Input()
  public isShown = false;

  @ViewChild("surveyItemRatingTypesElement", { static: false })
  public surveyItemRatingTypesElement!: NgSelectComponent;

  @Input()
  public get currentSurvey() {
    return this._currentSurvey;
  }

  public set currentSurvey(value) {
    if (!value) return;
    this._currentSurvey = value;
  }

  public get surveyItemRatingTypes() {
    return this._surveyItemRatingTypes;
  }

  // Reads all keys from the SurveyItemRatingTypes enum and stores them in an array.
  private setSurveyItemRatingTypes() {
    this._surveyItemRatingTypes = Object.keys(SurveyItemRatingType);
  }

  public get currentSurveyItem() {
    return this._currentSurveyItem;
  }

  public set currentSurveyItem(value) {
    if (!value) return;
    this._currentSurveyItem = value;
  }

  public async save() {
    await this.sessionService.updateSurvey(this.currentSurvey);
  }

  public async delete() {
    await this.sessionService.deleteSurvey(this.currentSurvey.id);
  }

  public async deleteSurveyItem(surveyItemId: string) {
    // TODO
  }

  public onClose() {
    this.close.next(null);
  }

  public async addSurveyItem() {

  }

}
