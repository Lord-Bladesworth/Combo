public enum ButtonEnum
{
    A, B, C, D, F, Q, W, E, R, T, Y, F1, F2, F3, F4, F5, F6,h, N
}
//Issue when using characters for the key: it's not possible to use F1,F2.....FX button enum in order to act as an identifier due to multiple characters are involved
//possible solutions:
 /*
  *         Replace F1 functions with single characters like Q W E R T Y 
  *         then create buttonEnum GUI translator for translating enum characters to human readables F1,F2,F3.... F6
  * 
 */