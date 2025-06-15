using UnityEngine;

public static class Utils {
  public static Vector3 ToIso(this Vector3 vector) {
    return Quaternion.Euler(0, 45, 0) * vector;
  }
}

// TODO: change to default class + customize settings
public static class GameSettings {
  public static KeyCode moveUpKey = KeyCode.W;
  public static KeyCode moveRightKey = KeyCode.D;
  public static KeyCode moveLeftKey = KeyCode.A;
  public static KeyCode moveDownKey = KeyCode.S;
  public static KeyCode dashKey = KeyCode.Space;
  public static KeyCode runKey = KeyCode.LeftShift;
}