import {
  Component, EventEmitter, Input,
  Output, ViewChild
} from "@angular/core";
import { NgSelectComponent } from "@ng-select/ng-select";
import { SessionService } from "../session/session.service";
import { Survey, SurveyItemRatingType } from '../shared/services/api';

@Component({
  selector: "app-create-survey-modal",
  templateUrl: "./create-survey-modal.component.html",
  //styleUrls: ["survey-modal.component.css"],
})
export class CreateSurveyModalComponent {
  

}
