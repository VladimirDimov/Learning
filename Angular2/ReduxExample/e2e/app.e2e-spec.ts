import { ReduxExamplePage } from './app.po';

describe('redux-example App', () => {
  let page: ReduxExamplePage;

  beforeEach(() => {
    page = new ReduxExamplePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
