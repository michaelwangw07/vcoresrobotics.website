import { Component, ViewChild, Injector, Output, EventEmitter, ElementRef, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { PostServiceProxy, CreatePostInput, API_BASE_URL } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';

import * as _ from "lodash";
import * as moment from 'moment';

declare var $ :any;

@Component({
    selector: 'create-post-modal',
    templateUrl: './create-post.component.html'
})
export class CreatePostComponent extends AppComponentBase implements OnInit{

    ngOnInit () {
        $.FroalaEditor.DefineIcon('alert', {NAME: 'info'});
        $.FroalaEditor.RegisterCommand('alert', {
          title: 'Hello',
          focus: false,
          undo: false,
          refreshAfterCallback: false,
    
          callback: function () {
            alert('Hello!');
          }
        });
      }

      public options: Object = {
        charCounterCount: true,
        language: "zh_cn", 
        // Set the image upload parameter.
        imageUploadParam: 'file',
 
        // Set the image upload URL.
        imageUploadURL: 'http://localhost:21021/UploadFiles',
 
        // Additional upload params.
        imageUploadParams: {type: 'file',name:'files', enctype:'multipart/form-data'},
 
        // Set request type.
        imageUploadMethod: 'POST',
        imageAllowedTypes: ['jpeg', 'jpg', 'png', 'gif'],
 
        // Set max image size to 5MB.
        imageMaxSize: 5 * 4096 * 3280,
 
        // Allow to upload PNG and JPG.
 
      };


    @ViewChild('createPostModal') modal: ModalDirective;
    @ViewChild('modalContent') modalContent: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active: boolean = false;
    saving: boolean = false;
    post: CreatePostInput = null;

    constructor(
        injector: Injector,
        private _postService: PostServiceProxy
    ) {
        super(injector);
    }

    show(): void {
        this.active = true;
        this.modal.show();
        this.post = new CreatePostInput();
        this.post.init({ isActive: true });
    }

    onShown(): void {
        $.AdminBSB.input.activate($(this.modalContent.nativeElement));
       
    }

    save(): void {
        this.saving = true;

        //this.post.date = moment($(this.postDate.nativeElement).data('DateTimePicker').date().format('YYYY-MM-DDTHH:mm:ssZ'));

        this._postService.createPostAsync(this.post)
            .finally(() => { this.saving = false; })
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}