import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Subject, Subscription } from "rxjs";
import { SessionService } from "../session/session.service";
import { Session, Survey } from '../shared/services/api';

@Component({
  selector: "app-surveys-overview",
  templateUrl: "./surveys-overview.component.html",
  styleUrls: ["surveys-overview.component.css"]
})
export class SurveysOverviewComponent {
  public session!: Session;
  private _subscriptions = new Subscription();
  public surveysOfCurrentSession?: Survey[] | null;

  public modalShown: { [key: string]: any } = {};
  public modalShown$ = new Subject<any>();

  constructor(private sessionService: SessionService, private router: Router, private route: ActivatedRoute) {
    this._subscriptions.add(
      this.sessionService.sessionChanged.subscribe(() => {
        //this.refreshSurveys();

        this.session = this.sessionService.currentSession;
        this.surveysOfCurrentSession = this.surveysOfCurrentSession;
      })
    );
  }

  public get surveysOfSession(): Survey[] {
    return this.session.surveys;
    // return this.sessionService.getAllSurveysOfSession(this.session.id);
  }

  public showModal($event: any, name: string, parameter: any) {
    $event.stopPropagation();

    this.modalShown[name] = parameter;
    this.modalShown$.next(this.modalShown);
  }

  public hideModal(name: string) {
    this.modalShown[name] = false;

    //this.refreshSurveys();
  }

  public async createSurvey(survey: Survey) {
    await this.sessionService.updateSurvey(survey);
    return;
  }

  public async ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id == null) {
      this.router.navigate(['/']);
      return;
    }

    //const isMobile = navigator.userAgent.toLowerCase().match(/mobile/i);
    //if (isMobile) {
    //  this.router.navigate(['/session', id, 'overview']);
    //}

    //await this.sessionService.get(+id);

    this.session = this.sessionService.currentSession;   
  }

  public ngOnDestroy() {
    this._subscriptions.unsubscribe();
  }

  //private refreshSurveys() {
   // this._surveys = null;
  //}
}
