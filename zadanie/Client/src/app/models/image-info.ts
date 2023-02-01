import { UserInfo } from "./user-info";

export interface ImageInfo {
  id: string;
  title: string;
  author: UserInfo;
  tags: string[];
  comments: string[];
  description?: string;
}
