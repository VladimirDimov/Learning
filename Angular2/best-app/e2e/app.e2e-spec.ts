import { BestAppPage } from './app.po';

describe('best-app App', () => {
  let page: BestAppPage;

  beforeEach(() => {
    page = new BestAppPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
