import {JobUnit} from "./job-unit";
import {OperationClaim} from "./operation-claim";

export interface User {
  userGuidId? : string;
  email? : string;
  nameSurname? : string;
  imageByte? : string;
  jobUnitDtos? : JobUnit[];
  operationClaimGetListDtos?: OperationClaim[];
}

export interface postUser{
  userGuidId? : string;
  email? : string;
  nameSurname? : string;
  imageByteString? : string;
}
