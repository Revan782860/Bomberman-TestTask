using UnityEngine;

namespace HeroCommands
{
     public abstract class Command : MonoBehaviour
     {
          public static float MoveSpeed;
          public abstract void Execute(Transform player);
          public virtual void Undo(Transform playerTransform) {}
     }

     public class MovementDownCommand : Command
     {
          public override void Execute(Transform player)
          {
               Move(player);
          }

          public override void Undo(Transform player)
          {
               player.transform.position -= MoveSpeed * Vector3.left * Time.deltaTime;
          }

          private void Move(Transform player)
          {
               player.transform.position += MoveSpeed * Vector3.left * Time.deltaTime;
          }
     }

     public class MovementLeftCommand : Command
     {
          public override void Execute(Transform player)
          {
               Move(player);
          }

          public override void Undo(Transform player)
          {
               player.transform.position -= MoveSpeed * Vector3.forward * Time.deltaTime;
          }

          private void Move(Transform player)
          {
               player.transform.position += MoveSpeed * Vector3.forward * Time.deltaTime;
          }
          
     }

     public class MovementRightCommand : Command
     {
          public override void Execute(Transform player)
          {
               Move(player);
          }

          public override void Undo(Transform player)
          {
               player.transform.Translate(new Vector3(0, 0, MoveSpeed * Time.deltaTime));
          }

          private void Move(Transform player)
          {
               player.transform.position -= MoveSpeed * Vector3.forward * Time.deltaTime;
          }

     }

     public class MovementUpCommand : Command
     {
          public override void Execute(Transform player)
          {
               Move(player);
          }

          public override void Undo(Transform player)
          {
               player.transform.position -= MoveSpeed * Vector3.right * Time.deltaTime;
          }

          private void Move(Transform player)
          {
               player.transform.position += MoveSpeed * Vector3.right * Time.deltaTime;
          }
     }
}