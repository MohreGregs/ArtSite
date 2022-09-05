import { BaseNameModel } from "./baseNameModel";

export interface SongModel extends BaseNameModel {
    interpret: string;
    link: string;
}
