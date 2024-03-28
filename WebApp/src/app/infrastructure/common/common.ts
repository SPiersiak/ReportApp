import { environment } from "../../../environments/environment";

export class Common {
  public static getUrl(controller: string, action?: string, ...pathSegments: string[]): string {
    const urlPath = `${environment.apiUrl}/${controller}/${action}`;
      if (pathSegments.length === 0) {
        return urlPath;
      }

      return `${urlPath}/${pathSegments.join('/')}`;
  }
}
