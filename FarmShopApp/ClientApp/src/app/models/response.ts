export interface IResponse<T> {
  isSuccess: boolean;
  isError: boolean;
  data: T;
  error: string;
}
