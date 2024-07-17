export interface Tally{
  tallyGuidId?:string;
  name?:string;
  jobDate?: Date;
  FirstDateTally?: Date;
  FinishDateTally?: Date;
  countHour?: number;
  studentGuidId?: string;
}
export interface TallyFace{
  tallyGuidId?:string;
  name?:string;
  jobDate?: string;
  FirstDateTally?: string;
  FinishDateTally?: string;
  countHour?: number;
  studentGuidId?: string;
}
