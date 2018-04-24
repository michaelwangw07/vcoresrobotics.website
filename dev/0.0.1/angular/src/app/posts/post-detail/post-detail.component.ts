import { Component, OnInit, Injector } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { PostDetailOutput, PostServiceProxy } from '@shared/service-proxies/service-proxies';

import * as _ from 'lodash';

@Component({
    templateUrl: './post-detail.component.html',
    animations: [appModuleAnimation()]
})
export class PostDetailComponent extends AppComponentBase implements OnInit {
    post: PostDetailOutput = new PostDetailOutput();
    postId:string;

    constructor(
        injector: Injector,
        private _postService: PostServiceProxy,
        private _router: Router,
        private _activatedRoute: ActivatedRoute
    ){
        super(injector);
    }

    ngOnInit():void{
        this._activatedRoute.params.subscribe((params: Params) => {
            this.postId = params['postId'];
            this.loadPost();
        });
    }

    loadPost() {
        this._postService.getPostDetailAsync(this.postId)
            .subscribe((result: PostDetailOutput) => {
                this.post = result;
            });
    }

    backToPostsPage() {
        this._router.navigate(['app/posts']);
    }

}