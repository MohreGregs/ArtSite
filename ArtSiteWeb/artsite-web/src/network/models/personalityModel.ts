import { BaseModel } from "./baseModel";
import { BaseNameModel } from "./baseNameModel";

export interface PersonalityModel extends BaseModel {
    personalityInfo: string;
    introverted: number;
    intuitiv: number;
    thinking: number;
    judging: number;
    assertive: number;
    traits: BaseNameModel[];
    flaws: BaseNameModel[];
}
