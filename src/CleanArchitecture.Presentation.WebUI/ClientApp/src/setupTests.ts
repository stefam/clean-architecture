//const localStorageMock = {
//  getItem: jest.fn(),
//  setItem: jest.fn(),
//  removeItem: jest.fn(),
//  clear: jest.fn(),
//};
//global.localStorage = localStorageMock;

//// Mock the request issued by the react app to get the client configuration parameters.
//window.fetch = () => {
//  return Promise.resolve(
//    {
//      ok: true,
//      json: () => Promise.resolve({
//        "authority": "https://localhost:7181",
//        "client_id": "CleanArchitecture.Presentation.WebUI",
//        "redirect_uri": "https://localhost:7181/authentication/login-callback",
//        "post_logout_redirect_uri": "https://localhost:7181/authentication/logout-callback",
//        "response_type": "id_token token",
//        "scope": "CleanArchitecture.Presentation.WebUIAPI openid profile"
//     })
//    });
//};

// jest-dom adds custom jest matchers for asserting on DOM nodes.
// allows you to do things like:
// expect(element).toHaveTextContent(/react/i)
// learn more: https://github.com/testing-library/jest-dom
import '@testing-library/jest-dom';