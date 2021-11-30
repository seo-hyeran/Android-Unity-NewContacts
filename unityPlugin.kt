package com.example.myapplication9

import android.app.Activity
import android.content.ClipboardManager
import android.content.Intent
import android.net.Uri
import android.os.Bundle
import android.provider.ContactsContract
import android.provider.MediaStore
import android.util.Log
import android.widget.EditText
import com.unity3d.player.UnityPlayer
import com.unity3d.player.UnityPlayerActivity

class unityPlugin : UnityPlayerActivity(){
 fun Open(InsertName: String,InsertEmail: String,InsertPhone: String){
     val intent = Intent(ContactsContract.Intents.Insert.ACTION).apply {
         // Sets the MIME type to match the Contacts Provider
         type = ContactsContract.RawContacts.CONTENT_TYPE
     }

     var name =InsertName
     var emailAddress = InsertEmail
     var phoneNumber = InsertPhone

     /* Assumes EditText fields in your UI contain an email address
      and a phone number.

      */

     /*
      * Inserts new data into the Intent. This data is passed to the
      * contacts app's Insert screen
      */
     intent.apply {
         // Inserts an name
         putExtra(ContactsContract.Intents.Insert.NAME, name)

         // Inserts an email address
         putExtra(ContactsContract.Intents.Insert.EMAIL, emailAddress)
         /*
          * In this example, sets the email type to be a work email.
          * You can set other email types as necessary.
          */
         putExtra(
             ContactsContract.Intents.Insert.EMAIL_TYPE,
             ContactsContract.CommonDataKinds.Email.TYPE_WORK
         )
         // Inserts a phone number
         putExtra(ContactsContract.Intents.Insert.PHONE, phoneNumber)
         /*
          * In this example, sets the phone type to be a work phone.
          * You can set other phone types as necessary.
          */
         putExtra(
             ContactsContract.Intents.Insert.PHONE_TYPE,
             ContactsContract.CommonDataKinds.Phone.TYPE_MOBILE
         )


     }

    UnityPlayer.currentActivity.startActivityForResult(intent,0)

 }

  /*  fun nameActive(InsertName: String){

    val name = InsertName

    Log.d(this.toString(),"nameActive="+name)
        intent.apply {
            // Inserts an name
          putExtra(ContactsContract.Intents.Insert.NAME, name)
        }

}

 fun EmailActive(InsertEmail: String){
        var Email= InsertEmail
        intent.apply {
            putExtra(ContactsContract.Intents.Insert.EMAIL, Email)
           /*
             * In this example, sets the email type to be a work email.
             * You can set other email types as necessary.
             */
            putExtra(
                ContactsContract.Intents.Insert.EMAIL_TYPE,
                ContactsContract.CommonDataKinds.Email.TYPE_WORK
            )

        }

    }

 fun PhoneActive(InsertPhone: String){
        var Phone =InsertPhone
        intent.apply {
            putExtra(ContactsContract.Intents.Insert.PHONE, Phone)
            /*
             * In this example, sets the phone type to be a work phone.
             * You can set other phone types as necessary.
             */
            putExtra(
                ContactsContract.Intents.Insert.PHONE_TYPE,
                ContactsContract.CommonDataKinds.Phone.TYPE_MOBILE
            )
        }

    }*/



       /* override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
        super.onActivityResult(requestCode, resultCode, data)


        if(requestCode==0 && resultCode == Activity.RESULT_OK){
            val Upath = data!!.data;
            val path = abs_path(Upath!!)
            //유니티에 값을 전달
            UnityPlayer.UnitySendMessage("AndroidPlugin","getImage",path)
        }
    }*/



    }


