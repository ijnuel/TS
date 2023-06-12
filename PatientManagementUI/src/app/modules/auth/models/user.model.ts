import { AuthModel } from './auth.model';

export class UserModel extends AuthModel {
  id: number = 0;
  username: string = "";
  password: string = "";
  fullname: string = "";
  email: string = "";
  roles: number[] = [];

  setUser(_user: unknown) {
    const user = _user as UserModel;
    this.id = user.id;
    this.username = user.username || '';
    this.password = user.password || '';
    this.fullname = user.fullname || '';
    this.email = user.email || '';
    this.roles = user.roles || [];
  }
}
