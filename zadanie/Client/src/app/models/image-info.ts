import { Comment } from "./comment";
import { UserInfo } from "./user-info";

export interface ImageInfo {
  id: string;
  title: string;
  author: UserInfo;
  tags: string[];
  comments: Comment[];
  description?: string;
}
