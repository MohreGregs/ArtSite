import { BaseModel } from "./baseModel";
import { BaseNameModel } from "./baseNameModel";

export interface GeneralInfoModel extends BaseModel {
    info: string;
    trivia: string;
    likes: BaseNameModel[];
    dislikes: BaseNameModel[];
}
