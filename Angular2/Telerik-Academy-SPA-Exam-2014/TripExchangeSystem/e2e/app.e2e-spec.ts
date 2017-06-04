import { TripExchangeSystemPage } from './app.po';

describe('trip-exchange-system App', () => {
  let page: TripExchangeSystemPage;

  beforeEach(() => {
    page = new TripExchangeSystemPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
